<template>
  <div>
    <v-select
      :items="langItems"
      v-model="langCur"
      item-text="display"
      item-value="id"
      class="language-select"
      @change="languageChanged"
    />
  </div>
</template>

<script>
import {
  mapState,
  mapActions
} from 'vuex'

export default {
  data () {
    return {
      langItems: [
        { id: 'ru', display: 'Русский' },
        { id: 'en', display: 'English' }
      ],
      langCur: '' }
  },
  computed: {
    ...mapState('app', ['lang'])
  },
  mounted () {
    this.langCur = this.lang
  },
  methods: {
    ...mapActions('app', ['setLang']),
    languageChanged (lang) {
      if (lang !== this.$i18n.locale) {
        this.$i18n.locale = lang
        this.$vuetify.lang.current = lang
        this.$moment.locale(lang)
        this.setLang(lang)
        this.$router.push('/home')
        this.$router.go()
      }
    }
  }
}
</script>

<style>
.language-select .v-input__slot:before
{
    border: 0 !important;
}
.language-select
{
    font-size: 12px!important;
}
</style>
