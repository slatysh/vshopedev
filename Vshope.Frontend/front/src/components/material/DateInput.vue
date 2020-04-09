<template>
  <div>
    <v-text-field
      v-model="date"
      :label="$t(label)"
      :disabled="disabled"
      @click="modal2=true"
    />
    <v-dialog
      ref="dialog"
      v-model="modal2"
      :return-value.sync="date"
      persistent
      lazy
      full-width
      width="290px"
    >
      <v-date-picker
        v-if="modal2"
        v-model="dateDialog"
        :header-color="color"
        full-width
      >
        <v-spacer/>
        <v-btn
          :color="color"
          flat
          @click="modal2 = false">Cancel</v-btn>
        <v-btn
          :color="color"
          flat
          @click="$refs.dialog.save(dateDialog)">OK</v-btn>
      </v-date-picker>
    </v-dialog>
  </div>
</template>

<script>
import {
  mapState
} from 'vuex'

export default {
  props: {
    label: {
      type: String,
      default: ''
    },
    dateExt: {
      type: String,
      default: null
    },
    disabled: {
      type: Boolean,
      default: false
    }
  },
  data () {
    return {
      date: null,
      dateDialog: null,
      modal2: false
    }
  },
  computed: {
    ...mapState('app', ['color'])
  },
  watch: {
    date: function (val) {
      this.$emit('change', val)
    },
    dateExt: function (val) {
      this.dateDialog = val
      this.date = val
    }
  }
}
</script>
