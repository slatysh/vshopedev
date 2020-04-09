
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
          :title="$t('common.productList')"
          max-width="1000px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-data-table
                  :headers="productHeaders"
                  :items="productItems"
                  :total-items="productTotal"
                  :pagination.sync="pagination"
                >
                  <template
                    slot="items"
                    slot-scope="props">
                    <td class="text-truncate item-vk-id-col"><span>{{ props.item.vkId }}</span></td>
                    <td class="text-truncate item-name-col"><span>{{ props.item.name }}<span/></span></td>
                    <td class="text-truncate item-description-col"><span>{{ props.item.description }}</span></td>
                    <td class="text-truncate item-price-col"><span>{{ props.item.price }}</span></td>
                  </template>
                </v-data-table>
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
  ProductGetList
} from '@/services'

export default {
  data () {
    return {
      productHeaders: [
        {
          text: this.$t('productList.itemVkId'),
          align: 'left',
          value: 'itemVkId'
        },
        {
          text: this.$t('productList.itemName'),
          align: 'left',
          value: 'itemName'
        },
        { text: this.$t('productList.itemDescription'), value: 'itemDescription' },
        { text: this.$t('productList.itemPrice'), value: 'itemPrice' }
      ],
      productItems: [],
      pagination: {},
      productTotal: 0,
      shopIdStr: ''
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['role', 'userCompanyId']),
    companyId: function () {
      return this.$route.params['companyId'] || this.userCompanyId
    }
  },
  watch: {
    pagination: {
      handler () {
        this.getProductItems()
      },
      deep: true
    }
  },
  mounted () {
  },
  methods: {
    getProductItems () {
      var requestModel = Object.assign({ companyId: this.companyId }, this.pagination)
      ProductGetList(requestModel).then((result) => {
        this.productItems = result.data.items
        this.productTotal = result.data.total
      })
    }
  }
}
</script>

<style scoped>
    .item-vk-id-col
    {
        max-width: 100px;
    }
    .item-name-col
    {
        max-width: 336px;
        min-width: 300px;
    }
    .item-description-col
    {
        max-width: 300px;
    }
    .item-price-col
    {
        max-width: 200px;
    }
</style>
