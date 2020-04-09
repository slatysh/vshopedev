
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
          :title="$t('common.invoiceManager')"
          max-width="1100px"
          class="mt-0"
        >
          <!-- <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <material-date-month-input
                  :date-ext="dateFilterDisplay"
                  label="invoiceManager.dateFilter"
                  @change="parseDateFilterAndRefresh"
                />
              </v-flex>
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
                    <td class="text-truncate item-shop-name-col">
                      <router-link
                        :to="`/shop/${props.item.shop.id}?curTab=tab-5`">{{ props.item.shop.name }}</router-link></td>
                    <td class="text-truncate item-period-col"> {{ props.item.period }}</td>
                    <td class="text-truncate item-summ-number-of-surprise-box-col">{{ props.item.summNumberOfSurpriseBox }}</td>
                    <td class="text-truncate item-price-col"><span v-t="'currency.rub'"/> {{ props.item.price }}</td>
                    <td class="text-truncate item-commission-col"><span v-t="'currency.rub'"/> {{ props.item.commission }}</td>
                    <td class="text-truncate item-summ-to-pay-to-shop-col"><span v-t="'currency.rub'"/> {{ props.item.summToPayToShop }}</td>
                    <td class="text-truncate item-summ-payed-to-shop-col"><span v-t="'currency.rub'"/> {{ props.item.summPayedToShop }}</td>
                    <td class="text-truncate item-status-col"><span v-t="props.item.statusStr"/></td>
                    <td class="text-truncate item-edit-col px-0">
                      <v-icon
                        @click="openEditItemDialog(props.item)"
                      >mdi-border-color</v-icon>
                    </td>
                  </template>
                </v-data-table>
              </v-flex>
            </v-layout>
          </v-container>-->
        </material-card>
        <!--<v-dialog
          v-model="editItemDialog"
          max-width="700px"
          persistent>
          <form>
            <v-card>
              <v-card-title>
                <span
                  v-t="''"
                  class="headline">{{ this.$t('payInvoiceManager.editItemTitle') }}</span>
              </v-card-title>
              <v-card-text>
                <v-container
                  grid-list-md
                  pt-1
                  pb-1>
                  <v-flex pb-1>
                    <v-text-field
                      v-model="editItemModel.shopName"
                      :label="$t('payInvoiceManager.shopName')"
                      readonly
                      disabled
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.period"
                      :label="$t('payInvoiceManager.period')"
                      readonly
                      disabled
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.summNumberOfSurpriseBox"
                      :label="$t('payInvoiceManager.summNumberOfSurpriseBox')"
                      readonly
                      disabled
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.price"
                      :prefix="$t('currency.rub')"
                      :label="$t('payInvoiceManager.price')"
                      readonly
                      disabled
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.commission"
                      :label="$t('payInvoiceManager.commission')"
                      :error-messages="commissionErrors"
                      :prefix="$t('currency.rub')"
                      type="number"
                      @input="$v.editItemModel.commission.$touch()"
                      @blur="$v.editItemModel.commission.$touch()"
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.summToPayToShop"
                      :label="$t('payInvoiceManager.summToPayToShop')"
                      :prefix="$t('currency.rub')"
                      readonly
                      disabled
                    />
                  </v-flex>
                  <v-flex>
                    <v-text-field
                      v-model="editItemModel.summPayedToShop"
                      :label="$t('payInvoiceManager.summPayedToShop')"
                      :error-messages="summPayedToShopErrors"
                      :prefix="$t('currency.rub')"
                      type="number"
                      @input="$v.editItemModel.summPayedToShop.$touch()"
                      @blur="$v.editItemModel.summPayedToShop.$touch()"
                    />
                  </v-flex>
                  <v-select
                    :items="statusItems"
                    :label="$t('payInvoiceManager.status')"
                    v-model="editItemModel.statusId"
                    :error-messages="statusIdErrors"
                    item-text="name"
                    item-value="id"
                    @input="$v.editItemModel.statusId.$touch()"
                    @blur="$v.editItemModel.statusId.$touch()"
                  />
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-container
                  grid-list-lg
                  pt-1
                  pb-1>
                  <v-layout
                    align-end
                    column>
                    <v-flex>
                      <v-btn
                        v-t="'common.close'"
                        :color="color"
                        @click="closeEditItemDialog()"
                      />
                      <v-btn
                        v-t="'common.submit'"
                        :color="color"
                        @click="updateModel()"
                      />
                    </v-flex>
                  </v-layout>
                </v-container>
              </v-card-actions>
            </v-card>
          </form>
        </v-dialog>-->
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
/* import {
  mapState
} from 'vuex'

import {
  PayInvoiceListByMonthGet,
  PayInvoiceStatusGetDict,
  PayInvoiceUpdate,

  TimeworkDatePeriodOffsetFormat,
  TimeworkMonthToDateTimeOffset,
  TimeworkDateTimeOffsetToMonth
} from '@/services'

import {
  ErrorConsts
} from '@/model'

import { required, between } from 'vuelidate/lib/validators'
*/
export default {
/*  data () {
    return {
      statusItems: [],
      invoiceHeaders: [
        {
          text: this.$t('payInvoiceManager.shopName'),
          align: 'left',
          value: 'shopName'
        },
        { text: this.$t('payInvoiceManager.period'), value: 'period' },
        { text: this.$t('payInvoiceManager.summNumberOfSurpriseBox'), value: 'summNumberOfSurpriseBox' },
        { text: this.$t('payInvoiceManager.price'), value: 'price' },
        { text: this.$t('payInvoiceManager.commission'), value: 'commission' },
        { text: this.$t('payInvoiceManager.summToPayToShop'), value: 'summToPayToShop' },
        { text: this.$t('payInvoiceManager.summPayedToShop'), value: 'summPayedToShop' },
        { text: this.$t('payInvoiceManager.status'), value: 'status' },
        { text: '', value: 'edit', sortable: false }
      ],
      invoiceItems: [],
      pagination: {},
      invoiceTotal: 0,
      editItemDialog: false,
      editItemModel: {
        shopName: '',
        summNumberOfSurpriseBox: '',
        price: '',
        commission: '',
        summToPayToShop: '',
        summPayedToShop: '',
        statusId: ''
      },
      dateFilter: '',
      dateFilterDisplay: ''
    }
  },
  validations: {
    editItemModel: {
      statusId: { required },
      commission: { required, between: between(0, ErrorConsts.VALIDATION_MAX_VALUE_SMALLNORMAL) },
      summPayedToShop: { required, between: between(0, ErrorConsts.VALIDATION_MAX_VALUE_SMALLNORMAL) }
    }
  },
  computed: {
    ...mapState('app', ['color']),
    commissionErrors () {
      const errors = []
      if (!this.$v.editItemModel.commission.$dirty) return errors
      !this.$v.editItemModel.commission.required && errors.push(this.$t('error.required', { field: this.$t('payInvoiceManager.commission') }))
      !this.$v.editItemModel.commission.between && errors.push(this.$t('error.between', { field: this.$t('payInvoiceManager.commission'), limitLow: 0, limitHigh: ErrorConsts.VALIDATION_MAX_VALUE_SMALLNORMAL }))
      return errors
    },
    summPayedToShopErrors () {
      const errors = []
      if (!this.$v.editItemModel.summPayedToShop.$dirty) return errors
      !this.$v.editItemModel.summPayedToShop.required && errors.push(this.$t('error.required', { field: this.$t('payInvoiceManager.summPayedToShop') }))
      !this.$v.editItemModel.summPayedToShop.between && errors.push(this.$t('error.between', { field: this.$t('payInvoiceManager.summPayedToShop'), limitLow: 0, limitHigh: ErrorConsts.VALIDATION_MAX_VALUE_SMALLNORMAL }))
      return errors
    },
    statusIdErrors () {
      const errors = []
      if (!this.$v.editItemModel.statusId.$dirty) return errors
      !this.$v.editItemModel.statusId.required && errors.push(this.$t('error.required', { field: this.$t('payInvoiceManager.status') }))
      return errors
    }
  },
  watch: {
    pagination: {
      handler () {
        this.getPayInvoiceList()
      },
      deep: true
    }
  },
  mounted () {
    this.getPayInvoiceStatusDict()
    this.dateFilter = TimeworkMonthToDateTimeOffset(this.$moment.utc())
    this.dateFilterDisplay = TimeworkDateTimeOffsetToMonth(this.dateFilter)
  },
  methods: {
    getPayInvoiceStatusDict () {
      PayInvoiceStatusGetDict().then((result) => {
        this.statusItems = result.data.items.map((item) => {
          item.name = this.$t(item.name)
          return item
        })
      })
    },
    getPayInvoiceList () {
      var requestModel = Object.assign(this.pagination, { dateFilter: this.dateFilter })
      PayInvoiceListByMonthGet(requestModel).then((result) => {
        this.invoiceItems = result.data.items.map((item) => {
          item.period = TimeworkDatePeriodOffsetFormat(item.dateTimeStart, item.dateTimeFinish)
          return item
        })
        this.invoiceTotal = result.data.total
      })
    },
    openEditItemDialog (item) {
      this.editItemModel = Object.assign(this.editItemModel, item)
      this.editItemDialog = true
    },
    closeEditItemDialog () {
      this.editItemDialog = false
    },
    updateModel () {
      this.$v.editItemModel.$touch()
      if (!this.$v.editItemModel.$invalid) {
        var requestModel = { payInvoiceDto: this.editItemModel }
        PayInvoiceUpdate(requestModel).then(() => {
          this.editItemDialog = false
          this.getPayInvoiceList()
        })
      }
    },
    parseDateFilterAndRefresh (val) {
      if (val !== this.dateFilterDisplay) {
        this.dateFilter = TimeworkMonthToDateTimeOffset(val)
        this.dateFilterDisplay = val
        this.getPayInvoiceList()
      }
    }
  } */
}
</script>

<style scoped>
    .item-shop-name-col
    {
        max-width: 206px;
        min-width: 100px;
    }
    .item-period-col
    {
        max-width: 180px;
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
    .item-summ-payed-to-shop-col
    {
        max-width: 100px;
    }
    .item-status-col
    {
        max-width: 100px;
        min-width: 80px;
    }
    .item-edit-col
    {
        min-width: 35px;
        max-width: 50px;
    }
</style>
