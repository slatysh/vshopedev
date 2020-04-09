<template>
  <v-dialog
    v-model="isAuthDialog"
    persistent
    max-width="450px"
  >
    <form v-if="authDialogStateComp === 'loginDialog'">
      <v-card>
        <v-card-title>
          <span
            v-t="'auth.loginRegister.login'"
            class="headline"/>
        </v-card-title>
        <v-card-text>
          <v-container
            grid-list-md
            pt-1
            pb-1>
            <v-flex>
              <v-text-field

                v-model="authLoginModel.userName"
                :error-messages="authLoginUserNameErrors"
                :label="$t('auth.loginRegister.login')"
                @input="$v.authLoginModel.userName.$touch()"
                @blur="$v.authLoginModel.userName.$touch()"
              />
            </v-flex>
            <v-flex>
              <v-text-field
                v-model="authLoginModel.password"
                :error-messages="authLoginPasswordErrors"
                :label="$t('auth.loginRegister.password')"
                type="password"
                @input="$v.authLoginModel.password.$touch()"
                @blur="$v.authLoginModel.password.$touch()"
              />
            </v-flex>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-container
            grid-list-lg
            pt-1
            pb-1>
            <v-layout
              align-center
              justify-center
              column>
              <v-flex>
                <v-btn
                  v-t="'auth.loginRegister.login'"
                  :color="color"
                  @click="login"
                />
              </v-flex>
            </v-layout>
          </v-container>
        </v-card-actions>
      </v-card>
    </form>
  </v-dialog>
</template>

<script>
import {
  mapActions,
  mapGetters,
  mapState
} from 'vuex'

import { required, maxLength } from 'vuelidate/lib/validators'

import { ErrorConsts, ExceptionCodes, ThrowErrorByExceptionResponse } from '@/model'

export default {
  data () {
    return {
      authLoginModel: {
        userName: '',
        password: ''
      }
    }
  },
  validations: {
    authLoginModel: {
      userName: { required, maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_SMALL) },
      password: { required, maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_SMALL) }
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['role', 'userCompanyId']),
    authDialogStateComp: {
      get () {
        return this.authDialogState()
      }
    },
    isAuthDialog: {
      get () {
        return this.authDialogState() !== 'none'
      }
    },
    authLoginUserNameErrors () {
      const errors = []
      if (!this.$v.authLoginModel.userName.$dirty) return errors
      !this.$v.authLoginModel.userName.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('auth.loginRegister.login'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      !this.$v.authLoginModel.userName.required && errors.push(this.$t('error.required', { field: this.$t('auth.loginRegister.login') }))
      return errors
    },
    authLoginPasswordErrors () {
      const errors = []
      if (!this.$v.authLoginModel.password.$dirty) return errors
      !this.$v.authLoginModel.password.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('auth.loginRegister.password'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      !this.$v.authLoginModel.password.required && errors.push(this.$t('error.required', { field: this.$t('auth.loginRegister.password') }))
      return errors
    }
  },
  methods: {
    ...mapActions('auth', ['hideAuthDialog', 'showAuthDialog', 'authRequest']),
    ...mapGetters('auth', ['authDialogState']),
    closeDialog () {
      this.hideAuthDialog()
    },
    login () {
      this.$v.authLoginModel.$touch()
      if (!this.$v.authLoginModel.$invalid) {
        this.authRequest({ userLoginDto: this.authLoginModel }).then((forceReload) => {
          this.hideAuthDialog()
        }).catch((error) => {
          if (!ThrowErrorByExceptionResponse(error, 400, ExceptionCodes.COMMON_NOT_EXIST, 'auth.loginRegister.loginExceptionUserNotExist') &&
              !ThrowErrorByExceptionResponse(error, 520, ExceptionCodes.BL_CODE_USER_NOT_CONFIRMED, 'auth.loginRegister.loginExceptionUserNotConfirmed')) {
            throw error
          }
        })
      }
    }
  }
}
</script>

<style lang="scss">
  .v-checkbox--hide-messages {
  .v-messages {
  display: none;
  }
  }
</style>
