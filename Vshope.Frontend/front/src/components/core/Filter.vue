<template>
  <div>
    <v-menu
      :close-on-content-click="false"
      bottom
      left
      min-width="300"
      max-width="300"
      nudge-left="12"
      offset-x
      transition="slide-y-transition"
    >
      <v-btn
        slot="activator"
        class="elevation-0"
        color="grey"
        dark
        fab
        fixed
        style="top: 96px;"
        top
      >
        <v-icon>mdi-settings</v-icon>
      </v-btn>

      <v-card>
        <v-container grid-list-xl>
          <v-layout wrap>
            <v-flex xs12>
              <div
                v-t="'core.filter.colorSetting'"
                class="text-xs-center body-2 text-uppercase sidebar-filter"/>

              <v-layout justify-center>
                <v-avatar
                  v-for="c in colors"
                  :key="c"
                  :class="[c === color ? 'color-active color-' + c: 'color-' + c]"
                  size="23"

                  @click="setColor(c)"
                />
              </v-layout>
              <v-divider class="mt-3"/>
            </v-flex>
            <v-flex
              xs12
            >
              <div
                v-t="'core.filter.images'"
                class="text-xs-center body-2 text-uppercase sidebar-filter"/>
            </v-flex>
            <v-flex
              v-for="img in images"
              :key="img"
              xs3
            >
              <v-img
                :class="[image === img ? 'image-active' : '']"
                :src="img"
                height="120"
                @click.native="setImage(img)"
              />
            </v-flex>
            <v-flex xs12>
              <div class="text-xs-center body-2 text-uppercase">
                <div
                  v-t="'core.filter.sharing'"
                  class=" sidebar-filter"/>
                <div>
                  <v-btn
                    color="indigo"
                    class="mr-2 v-btn-facebook"
                    fab
                    icon
                    small
                    round
                  >
                    <v-icon>mdi-facebook</v-icon>
                  </v-btn>
                  <v-btn
                    color="cyan"
                    class="v-btn-twitter"
                    fab
                    icon
                    small
                    round
                  >
                    <v-icon>mdi-twitter</v-icon>
                  </v-btn>
                </div>
              </div>
            </v-flex>
            <v-flex xs-12>
              <div class="text-xs-center body-2 text-uppercase">
                <a
                  v-t="'core.filter.goToExternalSite'"
                  :href="externalLink"
                  target="_blank"/>
              </div>
            </v-flex>
          </v-layout>
        </v-container>

      </v-card>
    </v-menu>
  </div>
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
    colors: [
      'first',
      'second',
      'third',
      'fourth',
      'fifth'
    ],
    images: [
      '',
      process.env.VUE_APP_FRONT_APP_PATH + '/img/vshopelogo.png'
    ],
    externalLink: process.env.VUE_APP_EXTERNAL_URL,
    UserRoleNames
  }),

  computed: {
    ...mapState('app', ['image', 'color']),
    color () {
      return this.$store.state.app.color
    }
  },

  methods: {
    ...mapMutations('app', ['setImage']),
    setColor (color) {
      this.$store.state.app.color = color
    }
  }
}
</script>

<style lang="scss">
  .v-avatar,
  .v-responsive {
    cursor: pointer;
  }
</style>
