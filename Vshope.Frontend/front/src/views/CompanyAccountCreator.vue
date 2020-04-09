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
          :title="$t('common.companyAccountCreator')"
          max-width="1000px"
          class="mt-0"
        >
          <v-container
            py-0
            px-3>
            <v-layout column>
              <v-flex>
                <company-company-create-edit
                  submit-button-name="companyAccountCreator.createAnAccount"/>
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
  data () {
    return {
    }
  },
  computed: {
    ...mapState('app', ['color'])
  }
}
</script>
