<template>
  <div>
        <p></p>
        <div class="row">
            <div class="col-sm-0 col-lg-4"></div>
          <div class="card border-secondary mb-3 text-center col-sm-12 col-lg-4" style="max-width: 30rem;">
              <div class="card-header">Welcome!</div>
              <p></p>
              <h1>Login </h1>
              <hr>
              <h1><i class="fas fa-utensils fa-4x" style="color: #884B99"></i></h1>
                <p>
              <router-link :to="{ name: 'login' }"><button type="button" class="btn btn-primary btn-lg btn-block">Login <i class="fas fa-sign-in-alt"></i></button></router-link> &nbsp;
              <router-link :to="{ name: 'register' }"><button type="button" class="btn btn-info btn-lg btn-block">New Account <i class="far fa-user-circle"></i></button></router-link>
                </p>
          </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'home'
}
</script>
