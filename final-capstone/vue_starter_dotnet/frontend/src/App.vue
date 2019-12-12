<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home </router-link>
      <router-link to="/preferenceForm">Preferences </router-link>
      <router-link to="/results">Results </router-link>
      <button v-on:click="logOut"> Log Out</button>
    </div>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'appView',
  methods: {
          logOut(){
          localStorage.clear();
          this.$router.push('/');

      }

  }
}
</script>
