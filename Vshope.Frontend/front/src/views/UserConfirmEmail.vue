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
          :title="$t('common.userConfirmEmail')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-text-field
                  :label="$t('userConfirmEmail.status')"
                  :value="$t(confirmEmailModel.status)"
                  readonly
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
  UserConfirmEmail
} from '@/services'

import {
  mapState
} from 'vuex'

export default {
  data: () => ({
    confirmEmailModel: {
      status: 'userConfirmEmail.statusConfirming'
    }
  }),
  computed: {
    ...mapState('app', ['color']),
    code: function () {
      return this.$route.query['code']
    }
  },
  mounted () {
    this.confirmEmail()
  },
  methods: {
    confirmEmail () {
      var requestModel = {
        code: this.code
      }
      UserConfirmEmail(requestModel).then((result) => {
        this.confirmEmailModel.status = 'userConfirmEmail.statusConfirmed'
      }).catch((error) => {
        this.confirmEmailModel.status = 'userConfirmEmail.statusError'
        throw error
      })
    }
  }
}
</script>
