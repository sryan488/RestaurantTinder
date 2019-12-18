<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <a class="navbar-brand" href="#"><i class="fas fa-hamburger"></i> Wild Card</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
    
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarColor01">
    <ul class="navbar-nav mr-auto">
     
      <li class="nav-item">
      
      </li>
      <li class="nav-item">
        
      </li>
    </ul>
    <span v-if="['results', 'preferenceForm', 'welcome'].includes($route.name)">
      
      <router-link :to="{ name: 'preferenceForm' }"><button type="button" class="btn btn-warning pull-sm-right">New Search <i class="fas fa-pizza-slice"></i></button></router-link>
      &nbsp;<router-link :to="{ name: 'results' }"><button type="button" class="btn btn-danger">Repeat Last Search <i class="fas fa-drumstick-bite"></i></button></router-link>
      &nbsp;<button class="btn btn-secondary my-2 my-sm-0" v-on:click="logOut">Log Out <i class="fas fa-sign-out-alt"></i></button>
    </span>
  </div>
</nav>
   
  
    
    <!-- <div id="nav">
      <router-link to="/">Home </router-link>
      <router-link to="/preferenceForm">Preferences </router-link>
      <router-link to="/results">Results </router-link>
      <button v-on:click="logOut"> Log Out</button>
    </div> -->

    
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