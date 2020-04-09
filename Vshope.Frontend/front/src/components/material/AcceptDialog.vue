<template>
  <v-dialog
    v-model="modal"
    persistent
    max-width="450px"
  >
    <v-card>
      <v-card-title>
        <span
          v-t="title"
          class="headline"/>
      </v-card-title>
      <v-card-text>
        <v-container
          grid-list-md
          pt-1
          pb-1>
          <v-flex>
            <span>{{ $t(txt, txtData) }}</span>
          </v-flex>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-container
          grid-list-lg
          pt-1
          pb-1
          pr-1>
          <v-layout
            align-end
            column>
            <v-flex>
              <v-btn
                v-t="'common.no'"
                :color="color"
                @click="decline"
              />
              <v-btn
                v-t="'common.yes'"
                :color="color"
                @click="accept"
              />
            </v-flex>
          </v-layout>
        </v-container>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import {
  mapState
} from 'vuex'

export default {
  props: {
    title: {
      type: String,
      default: ''
    },
    txt: {
      type: String,
      default: ''
    },
    txtData: {
      type: Object,
      default: null
    },
    modalExt: {
      type: Boolean,
      default: false
    }
  },
  data () {
    return {
      modal: false
    }
  },
  computed: {
    ...mapState('app', ['color'])
  },
  watch: {
    modalExt: function (val) {
      this.modal = val
    }
  },
  methods: {
    accept: function () {
      this.modal = false
      this.$emit('accept')
    },
    decline: function () {
      this.modal = false
      this.$emit('decline')
    }
  }
}
</script>
