<template>
  <div>
    <v-select
      v-if="productConditionItems.length"
      :items="productConditionItems"
      :label="$t('companyProductsInfoEdit.productCondition')"
      v-model="model.productConditionId"
      :error-messages="productConditionIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductConditionDict()"
    />
    <v-select
      v-if="productTypeItems.length"
      :items="productTypeItems"
      :label="$t('companyProductsInfoEdit.productType')"
      v-model="model.productTypeId"
      :error-messages="productTypeIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductTypeDict()"
    />
    <v-select
      v-if="productCategoryItems.length"
      :items="productCategoryItems"
      :label="$t('companyProductsInfoEdit.productCategory')"
      v-model="model.productCategoryId"
      :error-messages="productCategoryIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductCategoryDict()"
    />
    <v-select
      v-if="productGoodsTypeItems.length"
      :items="productGoodsTypeItems"
      :label="$t('companyProductsInfoEdit.productGoodsType')"
      v-model="model.productGoodsTypeId"
      :error-messages="productGoodsTypeIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductGoodsTypeDict()"
    />
    <v-select
      v-if="productApparelItems.length"
      :items="productApparelItems"
      :label="$t('companyProductsInfoEdit.productApparel')"
      v-model="model.productApparelId"
      :error-messages="productApparelIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductApparelDict()"
    />
    <v-select
      v-if="productSizeItems.length"
      :items="productSizeItems"
      :label="$t('companyProductsInfoEdit.productSize')"
      v-model="model.productSizeId"
      :error-messages="productSizeIdErrors"
      item-text="name"
      item-value="id"
      @input="inputProductSizeDict()"
    />
  </div>
</template>

<script>
import {
  mapState
} from 'vuex'

import {
  ProductTypeGetDict, ProductCategoryGetDict, ProductGoodsTypeGetDict, ProductApparelGetDict, ProductSizeGetDict,
  ProductConditionGetDict
} from '@/services'

import { required } from 'vuelidate/lib/validators'

export default {
  props: {
    productInfoModelExt: {
      type: Object,
      default: null
    }
  },
  data () {
    return {
      model: {
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
      productConditionItems: []
    }
  },
  validations () {
    return {
      model: {
        productTypeId: { required },
        productCategoryId: { required },
        productGoodsTypeId: { required },
        productApparelId: { },
        productSizeId: { },
        productConditionId: { required }
      }
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['role']),
    productTypeIdErrors () {
      const errors = []
      if (!this.$v.model.productTypeId.$dirty) return errors
      !this.$v.model.productTypeId.required && errors.push(this.$t('error.required', { field: this.$t('companyProductsInfoEdit.productType') }))
      return errors
    },
    productCategoryIdErrors () {
      const errors = []
      if (!this.$v.model.productCategoryId.$dirty) return errors
      !this.$v.model.productCategoryId.required && errors.push(this.$t('error.required', { field: this.$t('companyProductsInfoEdit.productCategory') }))
      return errors
    },
    productGoodsTypeIdErrors () {
      const errors = []
      if (!this.$v.model.productGoodsTypeId.$dirty) return errors
      !this.$v.model.productGoodsTypeId.required && errors.push(this.$t('error.required', { field: this.$t('companyProductsInfoEdit.productGoodsType') }))
      return errors
    },
    productApparelIdErrors () {
      const errors = []
      return errors
    },
    productSizeIdErrors () {
      const errors = []
      return errors
    },
    productConditionIdErrors () {
      const errors = []
      if (!this.$v.model.productConditionId.$dirty) return errors
      !this.$v.model.productConditionId.required && errors.push(this.$t('error.required', { field: this.$t('companyProductsInfoEdit.productCondition') }))
      return errors
    }
  },
  watch: {
    productInfoModelExt: function (val) {
      this.applyModel(val)
    }
  },
  mounted () {
    this.applyModel(this.productInfoModelExt)
  },
  methods: {
    getProductTypeDict () {
      return ProductTypeGetDict().then((result) => {
        this.productTypeItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductTypeDict () {
      this.$v.model.productTypeId.$touch()
      this.clearProductCategoryId()
      this.clearProductGoodsTypeId()
      this.clearProductApparelId()
      this.clearProductSizeId()
      this.getProductCategoryDict(this.model.productTypeId)
      this.productGoodsTypeItems = []
      this.productApparelItems = []
      this.productSizeItems = []
      this.$emit('change', this.model)
    },
    clearProductTypeId () {
      this.model.productTypeId = null
      this.$v.model.productTypeId.$reset()
    },

    getProductCategoryDict (productTypeId) {
      var requestModel = { productTypeId }
      return ProductCategoryGetDict(requestModel).then((result) => {
        this.productCategoryItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductCategoryDict () {
      this.$v.model.productCategoryId.$touch()
      this.clearProductGoodsTypeId()
      this.clearProductApparelId()
      this.clearProductSizeId()
      this.getProductGoodsTypeDict(this.model.productCategoryId)
      this.productApparelItems = []
      this.productSizeItems = []
      this.$emit('change', this.model)
    },
    clearProductCategoryId () {
      this.model.productCategoryId = null
      this.$v.model.productCategoryId.$reset()
    },

    getProductGoodsTypeDict (productCategoryId) {
      var requestModel = { productCategoryId }
      return ProductGoodsTypeGetDict(requestModel).then((result) => {
        this.productGoodsTypeItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductGoodsTypeDict () {
      this.$v.model.productGoodsTypeId.$touch()
      this.clearProductApparelId()
      this.clearProductSizeId()
      this.getProductApparelDict(this.model.productGoodsTypeId)
      this.productSizeItems = []
      this.$emit('change', this.model)
    },
    clearProductGoodsTypeId () {
      this.model.productGoodsTypeId = null
      this.$v.model.productGoodsTypeId.$reset()
    },

    getProductApparelDict (productGoodsTypeId) {
      var requestModel = { productGoodsTypeId }
      return ProductApparelGetDict(requestModel).then((result) => {
        this.productApparelItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductApparelDict () {
      this.$v.model.productApparelId.$touch()
      this.clearProductSizeId()
      this.getProductSizeDict(this.model.productGoodsTypeId, this.model.productApparelId)
      this.$emit('change', this.model)
    },
    clearProductApparelId () {
      this.model.productApparelId = null
      this.$v.model.productApparelId.$reset()
    },

    getProductSizeDict (productGoodsTypeId, productApparelId) {
      var requestModel = { productGoodsTypeId, productApparelId }
      return ProductSizeGetDict(requestModel).then((result) => {
        this.productSizeItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductSizeDict () {
      this.$v.model.productSizeId.$touch()
      this.$emit('change', this.model)
    },
    clearProductSizeId () {
      this.model.productSizeId = null
      this.$v.model.productSizeId.$reset()
    },

    getProductConditionDict () {
      return ProductConditionGetDict().then((result) => {
        this.productConditionItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    inputProductConditionDict () {
      this.$v.model.productConditionId.$touch()
      this.$emit('change', this.model)
    },
    clearProductConditionId () {
      this.model.productConditionId = null
      this.$v.model.productConditionId.$reset()
    },

    applyModel (val) {
      Promise.all([
        this.getProductTypeDict(),
        val.productTypeId && this.getProductCategoryDict(val.productTypeId),
        val.productCategoryId && this.getProductGoodsTypeDict(val.productCategoryId),
        val.productGoodsTypeId && this.getProductApparelDict(val.productGoodsTypeId),
        val.productApparelId && this.getProductSizeDict(val.productGoodsTypeId, val.productApparelId),
        this.getProductConditionDict()
      ]).then(() => {
        Object.assign(this.model, val)
      })
    }
  }
}
</script>
