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
          :title="$t('common.about')"
          max-width="600px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <v-text-field
                  :label="$t('about.email')"
                  :value="$t(aboutModel.email)"
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

export default {
  data: () => ({
    aboutModel: {
      email: 'inidev@yandex.ru'
    }
  }),
  computed: {
    ...mapState('app', ['color'])
  }
}
</script>
