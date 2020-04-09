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
          :title="$t('home.generalStatisticTitle')"
          max-width="600px"
          class="mt-0"
        >
          <!-- <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-select
                  :items="periodItems"
                  :label="$t('home.period')"
                  v-model="filterGeneralStatisticModel.periodId"
                  item-text="name"
                  item-value="id"
                  @change="periodChanged"
                />
                <v-data-table
                  :items="generalStatisticItems"
                  hide-actions
                  hide-headers
                >
                  <template
                    slot="items"
                    slot-scope="props">
                    <td v-t="props.item.name"/>
                    <td class="text-xs-right">{{ props.item.value }}</td>
                  </template>
                </v-data-table>
              </v-flex>
            </v-layout>
          </v-container>-->
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
/* import {
  mapState,
  mapActions,
  mapGetters
} from 'vuex'

import {
  GeneralStatisticGet, GeneralStatisticPeriodGetDict
} from '@/services'

import {
  GeneralStatisticPeriodEnum
} from '@/model' */

export default {
  /* data: () => ({
    filterGeneralStatisticModel: {
      periodId: GeneralStatisticPeriodEnum.today
    },
    periodItems: [],
    generalStatisticItems: []
  }),
  computed: {
    ...mapState('app', ['color']),
    ...mapGetters('auth', ['isAuthenticated'])
  },
  mounted () {
    this.getGeneralStatistic()
    this.getGeneralStatisticPeriodDict()
  },
  methods: {
    ...mapActions('auth', ['showAuthDialog']),
    showRegisterDialog () {
      this.showAuthDialog('registerDialog')
    },
    showLoginDialog () {
      this.showAuthDialog('loginDialog')
    },
    periodChanged (periodId) {
      if (periodId !== this.filterGeneralStatisticModel.periodId) {
        this.filterGeneralStatisticModel.periodId = periodId
        this.getGeneralStatistic()
      }
    },
    getGeneralStatistic () {
      var requestModel = {
        periodId: this.filterGeneralStatisticModel.periodId
      }
      GeneralStatisticGet(requestModel).then((result) => {
        var statArr = []
        statArr[0] = { name: 'home.generalStatistic.numberOfUsersRegistered', value: result.data.numberOfUsersRegistered }
        statArr[1] = { name: 'home.generalStatistic.numberOfSurpriseBoxOnline', value: result.data.numberOfSurpriseBoxOnline }
        statArr[2] = { name: 'home.generalStatistic.numberOfSurpriseBoxSold', value: result.data.numberOfSurpriseBoxSold }
        statArr[3] = { name: 'home.generalStatistic.numberOfShopPartners', value: result.data.numberOfShopPartners }
        this.generalStatisticItems = statArr
      })
    },
    getGeneralStatisticPeriodDict () {
      GeneralStatisticPeriodGetDict().then((result) => {
        this.periodItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    }
  } */
}
</script>
