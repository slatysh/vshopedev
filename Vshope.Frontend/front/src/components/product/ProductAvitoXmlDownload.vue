
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
          :title="$t('productAvitoXmlDownload.name')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout wrap>
              <v-flex>
                <v-textarea
                  :label="$t('productAvitoXmlDownload.productAdditionalDesc')"
                  v-model="model.productAdditionalDesc"
                  :error-messages="productAdditionalDescErrors"
                  @input="$v.model.productAdditionalDesc.$touch()"
                  @blur="$v.model.productAdditionalDesc.$touch()"
                />
                <material-date-input
                  :date-ext="model.dateStartDisplay"
                  label="productAvitoXmlDownload.dateStart"
                  @change="parseDateStartAndRefresh"
                />
                <material-date-input
                  :date-ext="model.dateFinishDisplay"
                  label="productAvitoXmlDownload.dateFinish"
                  @change="parseDateFinishAndRefresh"
                />
                <v-text-field
                  :label="$t('productAvitoXmlDownload.managerName')"
                  v-model="model.managerName"
                  :error-messages="managerNameErrors"
                  @input="$v.model.managerName.$touch()"
                  @blur="$v.model.managerName.$touch()"
                />
                <v-text-field
                  :label="$t('productAvitoXmlDownload.contactPhone')"
                  v-model="model.contactPhone"
                  :error-messages="contactPhoneErrors"
                  @input="$v.model.contactPhone.$touch()"
                  @blur="$v.model.contactPhone.$touch()"
                />
                <v-text-field
                  :label="$t('productAvitoXmlDownload.address')"
                  v-model="model.address"
                  :error-messages="addressErrors"
                  @input="$v.model.address.$touch()"
                  @blur="$v.model.address.$touch()"
                />
                <company-company-products-info-edit
                  ref="companyProductsInfoEdit"
                  :product-info-model-ext="productInfoModel"
                  @change="companyProductsInfoChanged"
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
                @click="downloadAvitoXml()">
                <v-icon>mdi-download</v-icon>
              </v-btn>
            </v-flex>
          </slot>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {
  mapState
} from 'vuex'
import {
  AvitoXmlFileDownload,
  TimeworkMomentFormat, TimeworkMomentParse,
  CompanyGet,
  ObjectIsEmpty, ObjectFetch
} from '@/services'

import {
  ErrorConsts
} from '@/model'

import { maxLength } from 'vuelidate/lib/validators'

export default {
  data () {
    return {
      model: {
        dateStart: '',
        dateStartDisplay: '',
        dateFinish: '',
        dateFinishDisplay: '',
        managerName: '',
        contactPhone: '',
        address: '',
        productTypeId: null,
        productCategoryId: null,
        productGoodsTypeId: null,
        productApparelId: null,
        productSizeId: null,
        productConditionId: null,
        productAdditionalDesc: null
      },
      productInfoModel: {
        productTypeId: null,
        productCategoryId: null,
        productGoodsTypeId: null,
        productApparelId: null,
        productSizeId: null,
        productConditionId: null
      },
      acceptDialogShow: false,
      acceptDialogTxtData: null,
      productCount: 0
    }
  },
  validations () {
    return {
      model: {
        managerName: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        contactPhone: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        address: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        productAdditionalDesc: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_BIG) }
      }
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['userCompanyId']),
    companyId: function () {
      return this.$route.params['companyId'] || this.userCompanyId
    },
    managerNameErrors () {
      const errors = []
      if (!this.$v.model.managerName.$dirty) return errors
      !this.$v.model.managerName.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('productAvitoXmlDownload.managerName'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },
    contactPhoneErrors () {
      const errors = []
      if (!this.$v.model.contactPhone.$dirty) return errors
      !this.$v.model.contactPhone.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('productAvitoXmlDownload.contactPhone'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },
    addressErrors () {
      const errors = []
      if (!this.$v.model.address.$dirty) return errors
      !this.$v.model.address.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('productAvitoXmlDownload.address'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },
    productAdditionalDescErrors () {
      const errors = []
      if (!this.$v.model.productAdditionalDesc.$dirty) return errors
      !this.$v.model.productAdditionalDesc.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('productAvitoXmlDownload.productAdditionalDesc'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_BIG }))
      return errors
    }
  },

  mounted () {
    this.model.dateStart = this.$moment().hour(12).minute(0).second(0)
    this.model.dateFinish = this.model.dateStart.clone().add(30, 'days')
    this.model.dateStartDisplay = TimeworkMomentFormat(this.model.dateStart)
    this.model.dateFinishDisplay = TimeworkMomentFormat(this.model.dateFinish)
    var requestModel = { companyId: this.companyId }
    CompanyGet(requestModel).then((result) => {
      this.applyData(result.data)
    })
  },
  methods: {
    companyProductsInfoChanged (model) {
      this.applyData(model)
    },

    downloadAvitoXml () {
      this.$v.model.$touch()
      if (!this.$v.model.$invalid &&
            !this.$refs.companyProductsInfoEdit.$v.model.$invalid) {
        var requestModel = {
          dto: this.model,
          companyId: this.companyId
        }
        AvitoXmlFileDownload(requestModel).then((result) => {
          var currentdate = this.$moment()
          var datetime = currentdate.format('YYYY-MM-DDTHH-mm-ss')
          var fileName = 'avitoXml_' + this.companyId + '_' + datetime + '.xml'
          const url = window.URL.createObjectURL(new Blob([
            new Uint8Array([0xEF, 0xBB, 0xBF]), // UTF-8 BOM
            result.data
          ], {
            type: 'application/xml; charset=utf-8'
          }))
          const link = document.createElement('a')
          link.href = url
          link.setAttribute('download', fileName) // or any other extension
          document.body.appendChild(link)
          link.click()
        })
      }
    },
    parseDateStartAndRefresh (val) {
      if (val !== this.model.dateStartDisplay) {
        this.model.dateStart = TimeworkMomentParse(val)
        this.model.dateFinish = this.dateStart.clone().add(30, 'days')
        this.model.dateStartDisplay = TimeworkMomentFormat(this.dateStart)
        this.model.dateFinishDisplay = TimeworkMomentFormat(this.dateFinish)
      }
    },
    parseDateFinishAndRefresh (val) {
      if (val !== this.model.dateFinishDisplay) {
        this.model.dateFinish = TimeworkMomentParse(val)
        this.model.dateFinishDisplay = TimeworkMomentFormat(this.dateFinish)
      }
    },
    applyData (companyData) {
      if (!ObjectIsEmpty(companyData)) {
        Object.assign(this.model, ObjectFetch(this.model, companyData))
        this.productInfoModel = ObjectFetch(this.productInfoModel, companyData)
      }
    }
  }
}
</script>
