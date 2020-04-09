<template>
  <md-field>
    <label v-t="label"/>
    <md-file
      v-model="fileModel"
      @md-change="postFile" />
  </md-field>
</template>

<script>
import {
  FileUploadTempURL
} from '@/services'

import axios from 'axios'

export default {
  props: {
    label: {
      type: String,
      default: ''
    }
  },
  data () {
    return {
      fileModel: null
    }
  },
  methods: {
    postFile (fileList) {
      if (fileList.length > 0) {
        let file = fileList[0]
        let formData = new FormData()
        formData.append('file', file)
        let config = {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        }
        axios.post(FileUploadTempURL(), formData, config).then((result) => {
          this.$emit('change', result.data)
        })
      } else {
        this.$emit('change', null)
      }
    }
  }

}
</script>
