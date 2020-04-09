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
          :title="$t('common.develop')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-text-field
                  :label="$t('develop.clientVersion')"
                  :value="developModel.clientVersion"
                  readonly
                />
                <v-text-field
                  :label="$t('develop.serverVersion')"
                  :value="developModel.serverVersion"
                  readonly
                />
              </v-flex>
            </v-layout>
          </v-container>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {
  mapState
} from 'vuex'

import {
  CommonGetServerVersion
} from '@/services'

export default {
  data: () => ({
    developModel: {
      clientVersion: process.env.VUE_APP_VERSION,
      serverVersion: ''
    }
  }),
  computed: {
    ...mapState('app', ['color'])
  },
  mounted () {
    this.getServerVersion()
  },
  methods: {
    getServerVersion () {
      CommonGetServerVersion().then((result) => {
        this.developModel.serverVersion = result.data
      }).catch((error) => {
        throw error
      })
    }
  }
}
</script>
