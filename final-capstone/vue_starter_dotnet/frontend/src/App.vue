<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <a class="navbar-brand" href="#"><i class="fas fa-hamburger"></i> Wild Card</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarColor01">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Features</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Pricing</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">About</a>
      </li>
    </ul>
    
      <button class="btn btn-secondary my-2 my-sm-0" v-on:click="logOut">Log Out</button>
    
  </div>
</nav>
   <div class="container">
  
    
    <!-- <div id="nav">
      <router-link to="/">Home </router-link>
      <router-link to="/preferenceForm">Preferences </router-link>
      <router-link to="/results">Results </router-link>
      <button v-on:click="logOut"> Log Out</button>
    </div> -->
<div class="row">
          <div class="col-lg-4">
          </div>
          <div class="col-lg-4 shadow-lg p-3 mb-5 bg-white rounded">
          <div class="card border-primary mb-3 text-center justify-content-center " style="max-width: 20rem;">
          <div class="card-header">Welcome <i class="fas fa-key"></i></div>
          <div class="card-body">
            <p class="card-text"><router-view/></p>
          </div>
          <div class="col-lg-4">
          </div>
 </div>
    
    
  </div>
</div>
    
  </div></div>
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
