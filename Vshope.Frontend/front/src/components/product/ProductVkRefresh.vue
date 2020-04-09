
<template>
  <v-container
    fill-height
    fluid
    grid-list-xl
  >
    <v-layout wrap>
      <v-flex>
        <material-card
          :color="color"
          :title="$t('productVkRefresh.name')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout wrap>
              <v-flex>
                <v-text-field
                  :label="$t('productVkRefresh.shopStr')"
                  v-model="model.shopStr"
                  disabled
                />
                <v-text-field
                  :label="$t('productVkRefresh.shopId')"
                  v-model="model.shopId"
                  disabled
                />
              </v-flex>
            </v-layout>
          </v-container>
          <slot
            slot="actions"
            name="actions">
            <v-flex class="text-xs-right">
              <v-btn
                :color="color"
                @click="acceptDialogShowInit()">
                <v-icon>mdi-refresh</v-icon>
              </v-btn>
            </v-flex>
            <material-accept-dialog
              :modal-ext="acceptDialogShow"
              :title="'productVkRefresh.getAndSaveListFromVk'"
              :txt="'productVkRefresh.getAndSaveListFromVkAcceptDialogTxt'"
              :txt-data="acceptDialogTxtData"
              @accept="acceptDialogAccept"
              @decline="acceptDialogHideInit"/>
          </slot>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {
  mapState,
  mapActions,
  mapGetters
} from 'vuex'
import {
  ProductGetCountFromVk,
  ProductGetAndSaveListFromVk,
  CompanyGet,
  VkworkAuthorizeUrl
} from '@/services'

import {
  ExceptionCodes,
  HandleErrorByExceptionResponse
} from '@/model'

export default {
  data () {
    return {
      model: {
        shopId: '',
        shopStr: ''
      },
      acceptDialogShow: false,
      acceptDialogTxtData: null,
      productCount: 0
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['userCompanyId']),
    ...mapGetters('auth', ['vkTokenLocalStorage']),
    companyId: function () {
      return this.$route.params['companyId'] || this.userCompanyId
    }
  },
  mounted () {
    var requestModel = { companyId: this.companyId }
    CompanyGet(requestModel).then((result) => {
      this.model.shopId = result.data.vkId
      this.model.shopStr = result.data.vkStr
    })
  },
  methods: {
    ...mapActions('info', ['showInfo']),
    ...mapActions('error', ['showError']),
    acceptDialogShowInit () {
      var requestModel = Object.assign({ companyId: this.companyId, vkToken: this.vkTokenLocalStorage() })
      ProductGetCountFromVk(requestModel).then((result) => {
        this.productCount = result.data
        this.acceptDialogTxtData = {
          shopId: this.shopId,
          productCount: this.productCount
        }
        this.acceptDialogShow = true
      }).catch((error) => {
        HandleErrorByExceptionResponse(error, 520, ExceptionCodes.VK_AUTH_TOKEN_INCORRECT, () => {
          window.open(VkworkAuthorizeUrl(), '_blank')
          this.showError(this.$t('productVkRefresh.exceptionVkAuthTokenInvalid'))
        })
      })
    },
    acceptDialogHideInit () {
      this.acceptDialogShow = false
    },
    acceptDialogAccept () {
      this.acceptDialogHideInit()
      this.getAndSaveListFromVk()
    },
    getAndSaveListFromVk () {
      if (this.companyId) {
        var requestModel = Object.assign({ companyId: this.companyId, vkToken: this.vkTokenLocalStorage() })
        ProductGetAndSaveListFromVk(requestModel).then(() => {
          this.showInfo(this.$t('productVkRefresh.productGetAndSaveListFromVkFinished'))
        }).catch((error) => {
          HandleErrorByExceptionResponse(error, 520, ExceptionCodes.VK_AUTH_TOKEN_INCORRECT, () => {
            window.open(VkworkAuthorizeUrl(), '_blank')
            this.showError(this.$t('productVkRefresh.exceptionVkAuthTokenInvalid'))
          })
        })
      }
    }
  }
}
</script>
