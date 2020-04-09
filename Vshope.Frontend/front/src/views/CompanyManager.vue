
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
          :title="$t('common.companyManager')"
          max-width="1000px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-data-table
                  :headers="companyHeaders"
                  :items="companyItems"
                  :total-items="companyTotal"
                  :pagination.sync="pagination"
                >
                  <template
                    slot="items"
                    slot-scope="props">
                    <td class="text-truncate item-name-col"><router-link :to="`/company/${props.item.id}`">{{ props.item.name }}</router-link></td>
                    <td class="text-truncate item-email-col"><span v-t="props.item.email"/></td>
                    <td class="text-truncate item-manager-name-col"><span v-t="props.item.managerName"/></td>
                    <td class="text-truncate item-contact-phone-col"><span v-t="props.item.contactPhone"/></td>
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
  CompanyGetList
} from '@/services'

export default {
  data () {
    return {
      companyHeaders: [
        {
          text: this.$t('companyManager.itemName'),
          align: 'left',
          value: 'itemName'
        },
        { text: this.$t('companyManager.itemEmail'), value: 'itemEmail' },
        { text: this.$t('companyManager.itemManagerName'), value: 'itemManagerName' },
        { text: this.$t('companyManager.itemContactPhone'), value: 'itemContactPhone' }
      ],
      companyItems: [],
      pagination: {},
      companyTotal: 0
    }
  },
  computed: {
    ...mapState('app', ['color'])
  },
  watch: {
    pagination: {
      handler () {
        this.getCompanyItems()
      },
      deep: true
    }
  },
  mounted () {
  },
  methods: {
    getCompanyItems () {
      var requestModel = Object.assign({}, this.pagination)
      CompanyGetList(requestModel).then((result) => {
        this.companyItems = result.data.items
        this.companyTotal = result.data.total
      })
    }
  }
}
</script>

<style scoped>
    .item-name-col
    {
        max-width: 336px;
        min-width: 300px;
    }
    .item-email-col
    {
        max-width: 200px;
    }
    .item-manager-name-col
    {
        max-width: 200px;
    }
    .item-contact-phone-col
    {
        max-width: 200px;
    }
</style>
