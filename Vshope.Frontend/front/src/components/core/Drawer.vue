<template>
  <v-navigation-drawer
    id="app-drawer"
    v-model="inputValue"
    app
    dark
    floating
    persistent
    mobile-break-point="991"
    width="280"
  >
    <v-img
      :src="image"
      height="100%"
    >
      <v-layout
        class="fill-height"
        tag="v-list"
        column
      >
        <v-list-tile avatar>
          <v-list-tile-avatar
            color="white"
          >
            <v-img
              :src="logo"
              contain
            />
          </v-list-tile-avatar>
          <v-list-tile-title
            v-t="title"
            class="title"/>
        </v-list-tile>
        <v-divider/>
        <v-list-tile
          v-for="(link, i) in links"
          :key="i"
          :to="link.to"
          :active-class="color"
          avatar
          class="v-list-item"
        >
          <v-list-tile-action>
            <v-icon>{{ link.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            v-t="link.text"
          />
        </v-list-tile>
      </v-layout>
    </v-img>
  </v-navigation-drawer>
</template>

<script>
// Utilities
import {
  mapMutations,
  mapState
} from 'vuex'

import {
  UserRoleNames
} from '@/model'

export default {
  data: () => ({
    logo: process.env.VUE_APP_FRONT_APP_PATH + '/img/vshopelogosmall.png',
    title: process.env.VUE_APP_TITLE
  }),
  computed: {
    ...mapState('app', ['image', 'color']),
    ...mapState('auth', ['role', 'userCompanyId', 'anonimousPathArr']),
    links () {
      var i = this.anonimousPathArr.indexOf(this.$route.path)
      if (i >= 0) {
      } else if (this.role === UserRoleNames.admin) {
        return [
          {
            to: '/',
            icon: 'mdi-view-dashboard',
            text: 'common.home'
          },
          {
            to: '/company-account-creator',
            icon: 'mdi-cart-plus',
            text: 'common.companyAccountCreator'
          },
          {
            to: '/company-manager',
            icon: 'mdi-cart-outline',
            text: 'common.companyManager'
          },
          {
            to: '/invoice-manager',
            icon: 'mdi-cash-usd',
            text: 'common.invoiceManager'
          }

        ]
      } else if (this.role === UserRoleNames.user) {
        return [
          {
            to: '/',
            icon: 'mdi-view-dashboard',
            text: 'common.home'
          },
          {
            to: `/company-by-user-profile`,
            icon: 'mdi-account-box-outline',
            text: 'companyProfile.name'
          },
          {
            to: `/company-by-user-vk`,
            icon: 'mdi-vk',
            text: 'companyVk.name'
          },
          {
            to: `/company-by-user-avito`,
            icon: 'mdi-arrow-down-bold-circle',
            text: 'companyAvito.name'
          },
          {
            to: `/company-by-user-statistic`,
            icon: 'mdi-chart-line',
            text: 'companyStatistic.name'
          },
          {
            to: `/company-by-user-invoices`,
            icon: 'mdi-cash-usd',
            text: 'companyInvoices.name'
          }
        ]
      } else {
        this.$store.dispatch('auth/authLogout')
        this.$store.dispatch('auth/showAuthDialog', 'loginDialog')
      }
    },
    inputValue: {
      get () {
        return this.$store.state.app.drawer
      },
      set (val) {
        this.setDrawer(val)
      }
    },
    items () {
      return this.$t('Layout.View.items')
    }
  },

  methods: {
    ...mapMutations('app', ['setDrawer', 'toggleDrawer'])
  }
}
</script>

<style lang="scss">
  #app-drawer {
    .v-list__tile {
      border-radius: 4px;

      &--buy {
        margin-top: auto;
        margin-bottom: 17px;
      }
    }
  }
</style>
