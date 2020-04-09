
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
          :title="$t('companyInvoices.name')"
          max-width="1000px"
          class="mt-0"
        >
          <!--<v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-data-table
                  :headers="invoiceHeaders"
                  :items="invoiceItems"
                  :total-items="invoiceTotal"
                  :pagination.sync="pagination"
                >
                  <template
                    slot="items"
                    slot-scope="props">
                    <td class="text-truncate item-period-col">{{ props.item.period }}</td>
                    <td class="text-truncate item-summ-number-of-surprise-box-col">{{ props.item.summNumberOfSurpriseBox }}</td>
                    <td class="text-truncate item-price-col">{{ props.item.price }}</td>
                    <td class="text-truncate item-commission-col">{{ props.item.commission }}</td>
                    <td class="text-truncate item-summ-to-pay-to-shop-col">{{ props.item.summToPayToShop }}</td>
                    <td class="text-truncate item-date-time-of-payment-col">{{ props.item.dateTimeOfPaymentDisplay }}</td>
                    <td class="text-truncate item-download-col px-0">
                      <v-icon
                        @click="downloadInvoice(props.item)"
                      >mdi-download</v-icon>
                    </td>
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
  mapState
} from 'vuex'

import {
  PayInvoiceListByShopGet,
  PayInvoiceInfoDownloadCsv,

  TimeworkDateTimeOffsetFormat,
  TimeworkDatePeriodOffsetFormat
} from '@/services' */

export default {
  /* data () {
    return {
      invoiceHeaders: [
        {
          text: this.$t('shopPayInvoices.period'),
          align: 'left',
          value: 'period'
        },
        { text: this.$t('shopPayInvoices.summNumberOfSurpriseBox'), value: 'summNumberOfSurpriseBox' },
        { text: this.$t('shopPayInvoices.price'), value: 'price' },
        { text: this.$t('shopPayInvoices.commission'), value: 'commission' },
        { text: this.$t('shopPayInvoices.summToPayToShop'), value: 'summToPayToShop' },
        { text: this.$t('shopPayInvoices.dateTimeOfPayment'), value: 'dateTimeOfPayment' },
        { text: '', value: 'download', sortable: false }
      ],
      invoiceItems: [],
      pagination: {},
      invoiceTotal: 0
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['userShopId']),
    shopId: function () {
      return this.$route.params['shopId'] || this.userShopId
    }
  },
  watch: {
    pagination: {
      handler () {
        this.getPayInvoiceByShopList()
      },
      deep: true
    }
  },
  methods: {
    getPayInvoiceByShopList () {
      var requestModel = Object.assign(this.pagination, { shopId: this.shopId })
      PayInvoiceListByShopGet(requestModel).then((result) => {
        this.invoiceItems = result.data.items.map((item) => {
          item.period = TimeworkDatePeriodOffsetFormat(item.dateTimeStart, item.dateTimeFinish)
          item.dateTimeOfPaymentDisplay = TimeworkDateTimeOffsetFormat(item.dateTimeOfPayment)
          return item
        })
        this.userTotal = result.data.total
      })
    },
    downloadInvoice (item) {
      var requestModel = { shopId: this.shopId, payInvoiceId: item.id }
      PayInvoiceInfoDownloadCsv(requestModel).then((result) => {
        var disposition = result.headers['content-disposition']
        var fileName = 'default' + TimeworkDateTimeOffsetFormat() + '.csv'
        if (disposition && disposition.indexOf('attachment') !== -1) {
          var fileNameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/
          var matches = fileNameRegex.exec(disposition)
          if (matches != null && matches[1]) {
            fileName = matches[1].replace(/['"]/g, '')
          }
        }
        const url = window.URL.createObjectURL(new Blob([
          new Uint8Array([0xEF, 0xBB, 0xBF]), // UTF-8 BOM
          result.data
        ], {
          type: 'text/csv; charset=utf-8'
        }))
        const link = document.createElement('a')
        link.href = url
        link.setAttribute('download', fileName) // or any other extension
        document.body.appendChild(link)
        link.click()
      })
    }
  } */
}
</script>

<style scoped>
    .item-period-col
    {
        max-width: 366px;
        min-width: 260px;
    }
    .item-summ-number-of-surprise-box-col
    {
        max-width: 100px;
    }
    .item-price-col
    {
        max-width: 100px;
    }
    .item-commission-col
    {
        max-width: 100px;
    }
    .item-summ-to-pay-to-shop-col
    {
        max-width: 100px;
    }
    .item-date-time-of-payment-col
    {
        max-width: 50px;
    }
    .item-download-col
    {
        min-width: 35px;
        max-width: 50px;
    }
</style>
