<template>
  <div>
    <v-snackbar
      :color="color"
      :bottom="bottom"
      :top="top"
      :left="left"
      :right="right"
      v-model="errorVisibleComp"
      dark
    >
      <v-icon
        color="white"
        class="mr-3"
      >
        mdi-bell-plus
      </v-icon>
      <div
        v-t="errorTxtComp"
        class="error-snackbar-text"/>
      <v-icon
        size="16"
        @click="hideError()"
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
    color: 'error',
    top: true,
    bottom: false,
    left: false,
    right: true
  }),
  computed: {
    errorVisibleComp: {
      get () {
        return this.errorVisible()
      }
    },
    errorTxtComp: {
      get () {
        return this.errorTxt()
      }
    }
  },
  methods: {
    ...mapActions('error', ['hideError']),
    ...mapGetters('error', ['errorVisible', 'errorTxt'])
  }
}
</script>

<style>
    .error-snackbar-text{
        height: 30px;
        line-height: 30px;
    }
</style>
