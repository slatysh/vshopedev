<template>
  <div>
    <v-snackbar
      :color="color"
      :bottom="bottom"
      :top="top"
      :left="left"
      :right="right"
      v-model="infoVisibleComp"
      dark
    >
      <v-icon
        color="white"
        class="mr-3"
      >
        mdi-bell-plus
      </v-icon>
      <div
        v-t="infoTxtComp"
        class="info-snackbar-text"/>
      <v-icon
        size="16"
        @click="hideInfo()"
      >
        mdi-close-circle
      </v-icon>
    </v-snackbar>
  </div>
</template>

<script>
import {
  mapActions,
  mapGetters
} from 'vuex'

export default {
  data: () => ({
    color: 'info',
    top: true,
    bottom: false,
    left: false,
    right: true
  }),
  computed: {
    infoVisibleComp: {
      get () {
        return this.infoVisible()
      }
    },
    infoTxtComp: {
      get () {
        return this.infoTxt()
      }
    }
  },
  methods: {
    ...mapActions('info', ['hideInfo']),
    ...mapGetters('info', ['infoVisible', 'infoTxt'])
  }
}
</script>

<style>
    .info-snackbar-text{
        height: 30px;
        line-height: 30px;
    }
</style>
