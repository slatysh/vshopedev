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
          :title="$t('common.vkAuth')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-text-field
                  :label="$t('vkAuth.status')"
                  :value="$t(vkAuthModel.status)"
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
  mapState,
  mapActions
} from 'vuex'

export default {
  data: () => ({
    vkAuthModel: {
      status: 'vkAuth.statusPending'
    }
  }),
  computed: {
    ...mapState('app', ['color'])

  },
  mounted () {
    var code = this.$route.query.code
    this.vkRequest(code).then(() => {
      this.vkAuthModel.status = 'vkAuth.statusSuccess'
    }).catch(() => {
      this.vkAuthModel.status = 'vkAuth.statusError'
    })
  },
  methods: {
    ...mapActions('auth', ['vkRequest'])
  }
}
</script>
