import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import PreferenceForm from './views/PreferenceForm.vue'
import Results from './views/Results.vue'
import welcome from './views/welcome.vue'
import Favorites from './views/Favorites.vue'
import Blacklist from './views/Blacklist.vue'
import Swipes from './views/Swipes.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/preferenceForm",
      name: "preferenceForm",
      component: PreferenceForm,
      meta: {
        requiresAuth: true
      }
    },
    {   
      path: "/results",
      name: "results",
      component: Results,
      meta: {
        requiresAuth: true
      }},
    {   
      path: "/welcome",
      name: "welcome",
      component: welcome,
      meta: {
        requiresAuth: true
      }
    },
    {   
      path: "/favorites",
      name: "favorites",
      component: Favorites,
      meta: {
        requiresAuth: true
      }
    },
    {   
      path: "/blacklist",
      name: "blacklist",
      component: Blacklist,
      meta: {
        requiresAuth: true
      }
    },
        {   
      path: "/blacklist",
      name: "blacklist",
      component: Blacklist,
      meta: {
        requiresAuth: true
      }
    },
    {   
      path: "/swipes",
      name: "swipes",
      component: Swipes,
      meta: {
        requiresAuth: true
      }
    },


  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const user = auth.getUser();

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
