<template>
  <div
    v-if="loading()"
    class="v-overlay v-overlay--active">
    <v-container fill-height>
      <v-layout
        row
        wrap
        align-center>
        <v-flex class="text-xs-center">
          <v-progress-circular
            :size="50"
            color="white"
            indeterminate
          />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import {
  mapGetters
} from 'vuex'

export default {
  data () {
    return {

    }
  },
  methods: {
    ...mapGetters('preloader', ['loading'])
  }
}
</script>
