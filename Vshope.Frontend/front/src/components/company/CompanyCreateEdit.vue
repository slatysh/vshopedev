<template>
  <v-form>
    <v-container>
      <v-layout wrap>
        <v-layout row>
          <v-flex md6 >
            <v-text-field
              :label="$t('companyCreateEdit.name')"
              v-model="companyCreateEditModel.name"
              :error-messages="nameErrors"
              @input="$v.companyCreateEditModel.name.$touch()"
              @blur="$v.companyCreateEditModel.name.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.vkStr')"
              v-model="companyCreateEditModel.vkStr"
              :error-messages="vkStrErrors"
              @input="$v.companyCreateEditModel.vkStr.$touch()"
              @blur="$v.companyCreateEditModel.vkStr.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.managerName')"
              v-model="companyCreateEditModel.managerName"
              :error-messages="managerNameErrors"
              @input="$v.companyCreateEditModel.managerName.$touch()"
              @blur="$v.companyCreateEditModel.managerName.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.contactPhone')"
              v-model="companyCreateEditModel.contactPhone"
              mask="8(###)###-##-##"
              placeholder="8(###)###-##-##"
              @input="$v.shopCreateEditModel.contactPhone.$touch()"
              @blur="$v.shopCreateEditModel.contactPhone.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.address')"
              v-model="companyCreateEditModel.address"
              :error-messages="addressErrors"
              @input="$v.companyCreateEditModel.address.$touch()"
              @blur="$v.companyCreateEditModel.address.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.email')"
              v-model="companyCreateEditModel.email"
              :error-messages="emailErrors"
              :readonly="isEdit"
              :disabled="isEdit"
              type="email"
              @blur="$v.companyCreateEditModel.email.$touch()"
            />
            <v-text-field
              :label="$t('companyCreateEdit.password')"
              v-model="companyCreateEditModel.password"
              :error-messages="passwordErrors"
              :type="isShowPassword ? 'text' : 'password'"
              @blur="$v.companyCreateEditModel.password.$touch()"
            />
          </v-flex>
          <v-flex md6 >
            <v-textarea
              :label="$t('companyCreateEdit.productAdditionalDesc')"
              v-model="companyCreateEditModel.productAdditionalDesc"
              :error-messages="productAdditionalDescErrors"
              height="100px"
              @input="$v.companyCreateEditModel.productAdditionalDesc.$touch()"
              @blur="$v.companyCreateEditModel.productAdditionalDesc.$touch()"
            />
            <company-company-products-info-edit
              ref="companyProductsInfoEdit"
              :product-info-model-ext="productInfoModel"
              @change="companyProductsInfoChanged"
            />
          </v-flex>
        </v-layout>
        <v-flex
          xs12
          text-xs-right
        >
          <v-btn
            v-t="submitButtonName"
            :color="color"
            :disabled="submitLoading"
            @click="createOrUpdateCompany()"/>
        </v-flex>
      </v-layout>
    </v-container>
  </v-form>
</template>

<script>
import {
  mapState,
  mapActions,
  mapGetters
} from 'vuex'

import {
  CompanyCreate, CompanyUpdate,
  VkworkAuthorizeUrl,
  ObjectIsEmpty, ObjectFetch
} from '@/services'

import {
  ErrorConsts, ExceptionCodes, ThrowErrorByExceptionResponse, HandleErrorByExceptionResponse,
  UserRoleNames
} from '@/model'

import { required, maxLength, minLength, email } from 'vuelidate/lib/validators'

export default {
  props: {
    isEdit: {
      type: Boolean,
      default: false
    },
    submitButtonName: {
      type: String,
      default: ''
    },
    companyCreateEditModelExt: {
      type: Object,
      default: null
    }
  },
  data () {
    return {
      companyCreateEditModel: {
        id: '',
        name: '',
        vkStr: '',
        managerName: '',
        contactPhone: '',
        address: '',
        email: '',
        password: '',
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
      productTypeItems: [],
      productCategoryItems: [],
      productGoodsTypeItems: [],
      productApparelItems: [],
      productSizeItems: [],
      submitLoading: false
    }
  },
  validations () {
    return {
      companyCreateEditModel: {
        name: { required, maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_SMALL) },
        vkStr: { required, maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_SMALL) },
        managerName: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        contactPhone: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        address: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        email: { required, email, maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_SMALL) },
        password: {
          required,
          minLength: minLength(ErrorConsts.VALIDATION_MIN_LENGTH_PASSWORD),
          maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL) },
        productAdditionalDesc: { maxLength: maxLength(ErrorConsts.VALIDATION_MAX_LENGTH_BIG) }
      }
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['role']),
    ...mapGetters('auth', ['vkTokenLocalStorage']),
    isShowPassword () {
      return this.role === UserRoleNames.admin
    },
    VkworkAuthorizeUrlCalc () {
      return VkworkAuthorizeUrl()
    },
    nameErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.name.$dirty) return errors
      !this.$v.companyCreateEditModel.name.required && errors.push(this.$t('error.required', { field: this.$t('companyCreateEdit.name') }))
      !this.$v.companyCreateEditModel.name.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.name'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      return errors
    },
    vkStrErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.vkStr.$dirty) return errors
      !this.$v.companyCreateEditModel.vkStr.required && errors.push(this.$t('error.required', { field: this.$t('companyCreateEdit.vkStr') }))
      !this.$v.companyCreateEditModel.vkStr.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.vkStr'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      return errors
    },
    managerNameErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.managerName.$dirty) return errors
      !this.$v.companyCreateEditModel.managerName.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.managerName'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },
    contactPhoneErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.contactPhone.$dirty) return errors
      !this.$v.companyCreateEditModel.contactPhone.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.contactPhone'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },
    addressErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.address.$dirty) return errors
      !this.$v.companyCreateEditModel.address.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.address'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_NORMAL }))
      return errors
    },

    emailErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.email.$dirty) return errors
      !this.$v.companyCreateEditModel.email.required && errors.push(this.$t('error.required', { field: this.$t('companyCreateEdit.email') }))
      !this.$v.companyCreateEditModel.email.email && errors.push(this.$t('error.email'))
      !this.$v.companyCreateEditModel.email.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.email'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      return errors
    },
    passwordErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.password.$dirty) return errors
      !this.$v.companyCreateEditModel.password.required && errors.push(this.$t('error.required', { field: this.$t('companyCreateEdit.password') }))
      !this.$v.companyCreateEditModel.password.minLength && errors.push(this.$t('error.minLength', { field: this.$t('companyCreateEdit.password'), limit: ErrorConsts.VALIDATION_MIN_LENGTH_PASSWORD }))
      !this.$v.companyCreateEditModel.password.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.password'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_SMALL }))
      return errors
    },
    productAdditionalDescErrors () {
      const errors = []
      if (!this.$v.companyCreateEditModel.productAdditionalDesc.$dirty) return errors
      !this.$v.companyCreateEditModel.productAdditionalDesc.maxLength && errors.push(this.$t('error.maxLength', { field: this.$t('companyCreateEdit.productAdditionalDesc'), limit: ErrorConsts.VALIDATION_MAX_LENGTH_BIG }))
      return errors
    }
  },
  watch: {
    companyCreateEditModelExt: function (val) {
      this.applyData(val)
    }
  },
  mounted () {
    if (this.isEdit) {
      this.applyData(this.companyCreateEditModelExt)
    } else {
    }
  },
  methods: {
    ...mapActions('info', ['showInfo']),
    ...mapActions('error', ['showError']),
    companyProductsInfoChanged (model) {
      this.applyData(model)
    },
    createOrUpdateCompany () {
      this.$v.companyCreateEditModel.$touch()
      if (!this.$v.companyCreateEditModel.$invalid &&
            !this.$refs.companyProductsInfoEdit.$v.model.$invalid) {
        var requestModel = {
          companyDto: this.companyCreateEditModel,
          vkToken: this.vkTokenLocalStorage()
        }
        this.submitLoading = true
        if (this.isEdit) {
          CompanyUpdate(requestModel).then((result) => {
            this.applyData(result.data)
            this.showInfo(this.$t('companyCreateEdit.companyUpdateSuccess'))
          })
            .catch((error) => {
              if (!ThrowErrorByExceptionResponse(error, 520, ExceptionCodes.VK_ID_INVALID, 'companyCreateEdit.exceptionVkIdInvalid') &&
                    !HandleErrorByExceptionResponse(error, 520, ExceptionCodes.VK_AUTH_TOKEN_INCORRECT, () => {
                      window.open(this.VkworkAuthorizeUrlCalc, '_blank')
                      this.showError(this.$t('companyCreateEdit.exceptionVkAuthTokenInvalid'))
                    })) {
                throw error
              }
            })
            .finally(() => {
              this.submitLoading = false
            })
        } else {
          CompanyCreate(requestModel).then((result) => {
            this.$router.push('/company-manager')
          }).catch((error) => {
            if (!ThrowErrorByExceptionResponse(error, 520, ExceptionCodes.VK_ID_INVALID, 'companyCreateEdit.exceptionVkIdInvalid') &&
                !ThrowErrorByExceptionResponse(error, 520, ExceptionCodes.BL_CODE_USER_ALREADY_EXIST, 'companyCreateEdit.exceptionUserAlreadyExist') &&
                !HandleErrorByExceptionResponse(error, 520, ExceptionCodes.VK_AUTH_TOKEN_INCORRECT, () => {
                  window.open(this.VkworkAuthorizeUrlCalc, '_blank')
                  this.showError(this.$t('companyCreateEdit.exceptionVkAuthTokenInvalid'))
                })) {
              throw error
            }
          }).finally(() => {
            this.submitLoading = false
          })
        }
      }
    },
    applyData (companyData) {
      if (!ObjectIsEmpty(companyData)) {
        debugger
        Object.assign(this.companyCreateEditModel, ObjectFetch(this.companyCreateEditModel, companyData))
        this.productInfoModel = ObjectFetch(this.productInfoModel, companyData)
      }
    }
  }
}
</script>
