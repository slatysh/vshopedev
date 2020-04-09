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
        <company-company-statistic/>
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
    }
  },
  computed: {
    ...mapState('app', ['color'])
  }
}
</script>
