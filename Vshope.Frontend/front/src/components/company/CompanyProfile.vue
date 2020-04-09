<template>
  <v-flex pt-2>
    <material-card
      :color="color"
      :title="$t('companyProfile.name')"
      max-width="1200px"
      class="mt-0"
    >
      <v-container
        py-0
        px-3>
        <v-layout row>
          <v-flex
            grow>
            <company-company-create-edit
              :company-create-edit-model-ext="companyProfileModel"
              :is-edit="true"
              submit-button-name="common.submit"
            />
          </v-flex>
          <v-flex
            shrink
            style="min-width:180px">
            <v-layout
              column>
              <v-btn
                v-t="'companyProfile.deleteCompany'"
                :color="color"
                @click="deleteDialogShowInit()"/>
              <material-accept-dialog
                :modal-ext="deleteDialogShow"
                :title="'companyProfile.deleteCompany'"
                :txt="'companyProfile.deleteCompanyAcceptDialogTxt'"
                :txt-data="companyProfileModel"
                @accept="deleteCompany"
                @decline="deleteDialogHideInit"/>
                <!--
              <v-text-field
                :label="$t('companyProfile.status')"
                :value="$t(companyProfileModel.statusStr)"
                readonly
              />
              <v-btn
                v-t="'companyProfile.putCompanyOnline'"
                v-if="companyProfileModel.statusId==companyStatusEnum.offline"
                :color="color"
                :disabled="companyStatusSubmitLoading"
                @click="updateCompanyStatus(CompanyStatusEnum.online)"/>
              <v-btn
                v-t="'companyProfile.putCompanyOffline'"
                v-if="companyProfileModel.statusId==CompanyStatusEnum.online"
                :color="color"
                :disabled="companyStatusSubmitLoading"
                @click="updateCompanyStatus(CompanyStatusEnum.offline)"/>-->
            </v-layout>
          </v-flex>
        </v-layout>
      </v-container>
    </material-card>
  </v-flex>
</template>

<script>
import {
  mapState
} from 'vuex'

/* import {
  CompanyStatusEnum
} from '@/model' */

import {
  CompanyGet, CompanyDelete
} from '@/services'

export default {
  data () {
    return {
      companyProfileModel: {
      },
      deleteDialogShow: false
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['userCompanyId']),
    companyId: function () {
      return this.$route.params['companyId'] || this.userCompanyId
    }
  },
  mounted () {
    var requestModel = { companyId: this.companyId }
    CompanyGet(requestModel).then((result) => {
      this.companyProfileModel = result.data
    })
  },
  methods: {
    deleteDialogShowInit () {
      this.deleteDialogShow = true
    },
    deleteDialogHideInit () {
      this.deleteDialogShow = false
    },
    deleteCompany () {
      this.deleteDialogShow = false
      var requestModel = { companyId: this.companyId }
      CompanyDelete(requestModel).then((result) => {
        this.$router.push('/company-manager')
      })
    }
  }
}
</script>
