<template>
<div>
  <p></p>
        <div class="row">
            <div class="col-4"></div>
          <div class="card border-secondary mb-3 text-center col-4" style="max-width: 30rem;">
  <div class="welcome">
    <h1>Home</h1>
    <div class="alert alert-dismissible alert-success">
      <button type="button" class="close" data-dismiss="alert">&times;</button>
      <strong>Well done!</strong> You successfully logged in to wild card!  Time to eat!.
      </div>
<p>
  <router-link :to="{ name: 'preferenceForm' }"><button type="button" class="btn btn-warning">New Search <i class="fas fa-pizza-slice"></i></button></router-link> &nbsp; <router-link :to="{ name: 'results' }"><button type="button" class="btn btn-danger">Repeat Last Search <i class="fas fa-drumstick-bite"></i></button></router-link>

</p>
  </div></div></div></div>
</template>

<script>
export default {
  name: 'welcome',
  components: {},
  data() {
    return {
     
    };
  }}
</script>
