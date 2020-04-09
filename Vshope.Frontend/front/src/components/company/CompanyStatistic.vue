<template>
  <v-flex pt-2>
    <material-card
      :color="color"
      :title="$t('companyStatistic.name')"
      max-width="1000px"
      class="mt-0"
    >
      <!--<v-container
        py-0
        px-3>
        <v-layout column>
          <v-flex>
            <v-data-table
              :items="companyStatisticItems"
              :headers="companyStatisticHeaders"
              hide-actions
            >
              <template
                slot="items"
                slot-scope="props">
                <td>{{ props.item.period }}</td>
                <td>{{ props.item.value }}</td>
              </template>
            </v-data-table>
          </v-flex>
        </v-layout>
      </v-container>-->
    </material-card>
  </v-flex>
</template>

<script>
/* import {
  mapState
} from 'vuex'

import {
  CompanyStatisticGet,
  StringworkCapitalize
} from '@/services' */

export default {
  /* data () {
    return {
      shopStatisticItems: [],
      shopStatisticHeaders: [
        {
          text: this.$t('shopStatistic.period'),
          align: 'left',
          value: 'period',
          sortable: false
        },
        {
          text: this.$t('shopStatistic.quantitySold'),
          value: 'value',
          sortable: false
        }
      ]
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['userShopId']),
    shopId: function () {
      return this.$route.params['shopId'] || this.userShopId
    }
  },
  mounted () {
    this.getShopStatistic()
  },
  methods: {
    getShopStatistic () {
      var requestModel = { shopId: this.shopId }
      ShopStatisticGet(requestModel).then((result) => {
        var statArr = []
        statArr[0] = { period: this.$t('shopStatistic.today'), value: result.data.quantitySoldToday }
        statArr[1] = { period: this.$t('shopStatistic.thisWeek'), value: result.data.quantitySoldThisWeek }

        statArr[2] = { period: StringworkCapitalize(this.$moment().day(1).format('dddd')), value: result.data.quantitySoldMonday }
        statArr[3] = { period: StringworkCapitalize(this.$moment().day(2).format('dddd')), value: result.data.quantitySoldTuesday }
        statArr[4] = { period: StringworkCapitalize(this.$moment().day(3).format('dddd')), value: result.data.quantitySoldWednesday }
        statArr[5] = { period: StringworkCapitalize(this.$moment().day(4).format('dddd')), value: result.data.quantitySoldThursday }
        statArr[6] = { period: StringworkCapitalize(this.$moment().day(5).format('dddd')), value: result.data.quantitySoldFriday }
        statArr[7] = { period: StringworkCapitalize(this.$moment().day(6).format('dddd')), value: result.data.quantitySoldSaturday }
        statArr[8] = { period: StringworkCapitalize(this.$moment().day(0).format('dddd')), value: result.data.quantitySoldSunday }

        statArr[9] = { period: this.$t('shopStatistic.thisMonth'), value: result.data.quantitySoldThisMonth }
        this.shopStatisticItems = statArr
      })
    }
  } */
}
</script>
