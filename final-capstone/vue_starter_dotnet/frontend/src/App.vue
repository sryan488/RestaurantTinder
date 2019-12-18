<template>
<div id="app">
<nav class="navbar navbar-expand-sm navbar-jw navbar-dark bg-primary mx-auto">
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#appnav" aria-controls="appnav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
  <a class="navbar-brand" href="#"><i class="fas fa-hamburger fa-spin-hover"></i> Wild Card</a>
  <div class="collapse navbar-collapse" id="appnav">
    <div class="nav navbar-nav float-lg-right">
      
        
     <span v-if="['results', 'preferenceForm', 'welcome'].includes($route.name)">
      
      <router-link :to="{ name: 'preferenceForm' }"><button type="button" class="btn btn-warning pull-sm-right">New Search <i class="fas fa-pizza-slice"></i></button></router-link>
      &nbsp;<router-link :to="{ name: 'results' }"><button type="button" class="btn btn-danger">Repeat Last Search <i class="fas fa-drumstick-bite"></i></button></router-link>
      &nbsp;<button class="btn btn-secondary my-2 my-sm-0" v-on:click="logOut">Log Out <i class="fas fa-sign-out-alt"></i></button>
    </span>
    </div>
  </div>
</nav>
    <router-view/>
  </div>
</template>

<script>

export default {
  name: 'appView',
  data(){
    // TODO: 
    // userName: ""
  },
  methods: {
          logOut(){
          localStorage.clear();
          this.$router.push('/');

      }
  }
}
</script>
<style scoped>

</style>