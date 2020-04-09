
<template>
  <v-container
    fill-height
    fluid
    grid-list-xl
  >
    <v-layout
      wrap
    >
      <v-flex
        v-if="role==UserRoleNames.user"
        pt-0>
        <product-product-list/>
      </v-flex>
      <v-flex
        v-if="role==UserRoleNames.admin"
        pt-0>
        <general-general-statistic/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {
  mapState
} from 'vuex'

import {
  UserRoleNames
} from '@/model'

export default {
  data () {
    return {
      UserRoleNames
    }
  },
  computed: {
    ...mapState('app', ['color']),
    ...mapState('auth', ['role'])
  }
}
</script>
