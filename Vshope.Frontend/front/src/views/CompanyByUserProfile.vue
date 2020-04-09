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
            </v-layout>
          </v-container>
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
  CompanyGet
} from '@/services'

export default {
  data () {
    return {
      companyProfileModel: {
      }
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
  }
}
</script>
