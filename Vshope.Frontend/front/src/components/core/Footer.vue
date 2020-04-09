<template>
  <v-footer
    id="core-footer"
    absolute
    height="82"
  >
    <div class="footer-items">
      <span
        v-for="link in links"
        :key="link.name"
      >
        <a
          v-t="link.name "
          :href="link.Link"
          class="tertiary--text footer-links"/>
      </span>
      <!--<common-language-select class="footer-links pt-0 pb-0 d-inline-block language-select-container"/>-->
    </div>
    <v-spacer/>
    <span class="font-weight-light copyright">
      2019
      <a
        href="/about"
        target="_blank">IniDev Team</a>
    </span>
  </v-footer>
</template>

<script>
export default {
  data: () => ({
    links: [
      { name: 'common.home', Link: '/home' },
      { name: 'common.about', Link: '/about' },
      { name: 'common.develop', Link: '/develop' }
    ]
  })
}
</script>

<style>
#core-footer {
  z-index: 0;
}
.language-select-container
{
    width: 100px;
}
</style>
