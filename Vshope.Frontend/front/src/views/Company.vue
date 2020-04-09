
<template>
  <v-container
    fill-height
    fluid
    grid-list-xl
  >
    <v-layout
      wrap
    >
      <v-flex pt-0>
        <v-tabs
          :slider-color="color"
          v-model="curTab"
        >
          <v-tab
            href="#tab-1">
            {{ $t("companyProfile.name") }}
          </v-tab>
          <v-tab
            href="#tab-2">
            {{ $t("companyStatistic.name") }}
          </v-tab>
          <v-tab
            href="#tab-3">
            {{ $t("companyInvoices.name") }}
          </v-tab>
          <v-tab
            href="#tab-4">
            {{ $t("productList.name") }}
          </v-tab>
          <v-tab-item
            :value="'tab-1'"
            class="pt-4"
            lazy
          >
            <company-company-profile/>
          </v-tab-item>
          <v-tab-item
            :value="'tab-2'"
            class="pt-4"
            lazy
          >
            <company-company-statistic/>
          </v-tab-item>
          <v-tab-item
            :value="'tab-3'"
            class="pt-4"
            lazy
          >
            <company-company-invoices/>
          </v-tab-item>
          <v-tab-item
            :value="'tab-4'"
            class="pt-4"
            lazy
          >
            <product-product-list/>
          </v-tab-item>
        </v-tabs>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {
  mapState
} from 'vuex'

export default {
  data () {
    return {
      curTab: this.$route.query['curTab'] || 'tab-1'
    }
  },
  computed: {
    ...mapState('app', ['color'])
  }
}
</script>
