<template>
  <v-toolbar
    id="core-toolbar"
    app
    flat
    prominent
    style="background: #eee;"
  >
    <div class="v-toolbar-title">
      <v-toolbar-title
        class="tertiary--text font-weight-light"
      >
        <v-btn
          v-if="responsive"
          class="default v-btn--simple"
          dark
          icon
          @click.stop="onClickBtn"
        >
          <v-icon>mdi-view-list</v-icon>
        </v-btn>
        <v-breadcrumbs
          v-if="breadcrumbItems!=null"
          :items="breadcrumbItems"
          pl-0
        >
          <template
            slot="item"
            slot-scope="props">
            <router-link
              v-t="props.item.text"
              :to="props.item.href"
              :class="[props.item.disabled && 'disabled']"/>
          </template>
        </v-breadcrumbs>
        <span
          v-t="title"
          v-if="breadcrumbItems==null"/>
      </v-toolbar-title>
    </div>

    <v-spacer />
    <v-toolbar-items>
      <v-flex
        align-center
        layout
        py-2
      >
        <a
          :href="vkworkAuthorizeUrlCalc"
          class="toolbar-items"
          target="_blank"
        >
          Vk
        </a>
        <router-link
          v-ripple
          class="toolbar-items"
          to="/"
        >
          <v-icon color="tertiary">mdi-view-dashboard</v-icon>
        </router-link>
        <router-link
          v-ripple
          v-if="!hideLogoutBtn"
          class="toolbar-items"
          to=""
          @click.native="logout"
        >
          <v-icon
            color="tertiary">mdi-logout-variant</v-icon>
        </router-link>
      </v-flex>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>

import {
  mapMutations,
  mapState
} from 'vuex'

import {
  VkworkAuthorizeUrl
} from '@/services'

export default {
  data: () => ({
    title: null,
    breadcrumbItems: null,
    responsive: false,
    responsiveInput: false
  }),
  computed: {
    ...mapState('auth', ['anonimousPathArr']),
    hideLogoutBtn () {
      var i = this.anonimousPathArr.indexOf(this.$route.path)
      if (i < 0) {
        return false
      } else {
        return true
      }
    },
    vkworkAuthorizeUrlCalc () {
      return VkworkAuthorizeUrl()
    }
  },
  watch: {
    '$route' (val) {
      this.title = val.name
      if (val.meta.hasOwnProperty('breadcrumbItems')) {
        this.breadcrumbItems = val.meta.breadcrumbItems
      } else {
        this.breadcrumbItems = null
      }
    }
  },

  mounted () {
    this.onResponsiveInverted()
    window.addEventListener('resize', this.onResponsiveInverted)
  },
  beforeDestroy () {
    window.removeEventListener('resize', this.onResponsiveInverted)
  },
  methods: {
    ...mapMutations('app', ['setDrawer', 'toggleDrawer']),
    onClickBtn () {
      this.setDrawer(!this.$store.state.app.drawer)
    },
    onResponsiveInverted () {
      if (window.innerWidth < 991) {
        this.responsive = true
        this.responsiveInput = false
      } else {
        this.responsive = false
        this.responsiveInput = true
      }
    },
    logout () {
      this.$store.dispatch('auth/authLogout')
      this.$store.dispatch('auth/showAuthDialog', 'loginDialog')
    }
  }
}
</script>

<style>
  #core-toolbar a {
    text-decoration: none;
  }
</style>
