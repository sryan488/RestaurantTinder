<template>
  <section class="container">
    <div class="fixed header">
      <i class="material-icons" @click="index = 0">Refresh</i>
    </div>
    <div
      v-if="current"
      class="fixed fixed--center"
      style="z-index: 3"
      :class="{ 'transition': isVisible }">
      <Vue2InteractDraggable
        v-if="isVisible"
        :interact-out-of-sight-x-coordinate="500"
        :interact-max-rotation="15"
        :interact-x-threshold="200"
        :interact-y-threshold="200"
        :interact-event-bus-events="interactEventBus"
        interact-block-drag-down
        @draggedRight="emitAndNext('match'); swipeRight()"
        @draggedLeft="emitAndNext('reject'); swipeLeft()"
        class="rounded-borders card card--one">
        <div style="height: 100%">
          <!-- <img
            :src="require(`${current.imgUrl}`)"
            class="rounded-borders"/> -->
          <img :src="current.imgUrl" class="rounded-borders"/> 
          <div class="text">
            
            <h2>{{current.name}}</h2>
        <i class="far fa-star" v-if="!isFavorite" v-on:click="makeFavorite"></i>
        <i class="fas fa-star" v-if="isFavorite" v-on:click="unFavorite"></i>
            <div v-for="cash in current.maxPriceRange" v-bind:key="cash">
            <span>$</span>
            </div>
            <!-- <h2 color="white"> RESTAURANTS: {{restaurants[0].name}}</h2> -->
          </div>
        </div>
      </Vue2InteractDraggable>
    </div>
    <div
      v-if="next"
      class="rounded-borders card card--two
       fixed fixed--center"
      style="z-index: 2">
      <div style="height: 100%">
        <!-- <img
          :src="require(`${next.imgUrl}`)"
          class="rounded-borders"/> -->
          <img :src="next.imgUrl" class="rounded-borders"/> 
        <div class="text">
            <h2>{{next.name}}</h2>
            <div v-for="cash in next.maxPriceRange" v-bind:key="cash">
            <span>$</span>
            </div>

            <!-- <h2 color="white"> RESTAURANTS: {{restaurants[1].name}}</h2> -->
          </div>
      </div>
    </div>
    <div
      v-if="index + 2 <= restaurants.length"
      class="rounded-borders card card--three fixed fixed--center"
      style="z-index: 1">
      <div style="height: 100%">
      </div>
    </div>
    <div class="footer fixed">
      <div class="btn btn--decline" @click="reject; swipeRight()">
          <i class="material-icons">Dislike</i>
      </div>
        <router-link :to="{ name: 'swipes' }"><button type="button" class="btn ">DONE</button></router-link>
      <div class="btn btn--like" @click="match; swipeLeft()">
          <i class="material-icons">Like</i>
      </div>
      <!-- <div v-for="restaurant in restaurants" v-bind:key="restaurant">
        <p>NAME: {{restaurant.name}}</p>
        
      </div> -->
    </div>
  </section>
</template>

<script>
import auth from '../auth';
import { Vue2InteractDraggable, InteractEventBus } from 'vue2-interact'
const EVENTS = {
  MATCH: 'match',
  REJECT: 'reject'
}

export default {
  name: 'SwipeableCards',
  components: { Vue2InteractDraggable },
  data() {
    return {
      isVisible: true,
      index: 0,
      interactEventBus: {
        draggedRight: EVENTS.MATCH,
        draggedLeft: EVENTS.REJECT
      },
      cards: [
        { src: '1.jpg', name: 'Karina', age: 7 },
        { src: '2.jpg', name: 'Alexander', age: 5 },
        { src: '3.jpg', name: 'Bona', age: 3 },
      ],
      restaurants: [],
      favoritesList: [],
      isFavorite: false
    }
  },
  computed: {
    current() {
      return this.restaurants[this.index]
    },
    next() {
      return this.restaurants[this.index + 1]
    },
  },
  methods: {
    match() {
      console.log("match");
      InteractEventBus.$emit(EVENTS.MATCH);
      this.checkFavorite();
    },
    reject() {
      console.log("reject");
      InteractEventBus.$emit(EVENTS.REJECT);
      this.checkFavorite();
    },
    emitAndNext(event) {
      console.log("emit and next");
      this.checkFavorite(this.next.restaurantID);
      this.$emit(event, this.index)
      setTimeout(() => this.isVisible = false, 200)
      setTimeout(() => {
        this.index++
        this.isVisible = true
      }, 200)
    },
    getFavorites(){
    },
      makeFavorite(){
        return fetch(`${process.env.VUE_APP_REMOTE_API}/test/AddFavorite`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            body: JSON.stringify(this.current)
        })
        .then((response) => {
            if (response.ok) {
              this.isFavorite = true;
            }})
      },
      unFavorite(){
        return fetch(`${process.env.VUE_APP_REMOTE_API}/test/RemoveFavorite`, {
            method: 'DELETE',
            headers: {
                "Content-Type": "application/json",
                Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            body: JSON.stringify(this.current)
        })
        .then((response) => {
            if (response.ok) {
              this.isFavorite = false;
            }})
      },
    populateRestaurants(){
          fetch(`${process.env.VUE_APP_REMOTE_API}/test/GetRestaurants`, {
            headers: {
            "Content-Type": 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            })
              .then((response) => {
                if (response.ok) {
                return response.json();
                }
                else if (!response.ok) {
                  this.$router.push('/preferenceForm')
                }})
                    .then((restaurants) => {
                        this.restaurants = restaurants;
                        this.populateFavorites();
                        })
                          .catch((err) => console.error(err));
    },
    populateFavorites(){
          fetch(`${process.env.VUE_APP_REMOTE_API}/test/GetFavorites`, {
            headers: {
            "Content-Type": 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            })
              .then((response) => {
                  if (response.ok) {
                      return response.json();
                    }
              })
                .then((favoritesList) => {
                    this.favoritesList = favoritesList;
                    this.checkFavorite(this.current.restaurantID);
                        })
                          .catch((err) => console.error(err));
    },
    checkFavorite(restaurantID) {
      this.isFavorite = false;
      console.log("it at least made it to check favorite");
      for(let i = 0; i < this.favoritesList.length; i++){
              if (this.favoritesList[i].restaurantID === restaurantID){
                this.isFavorite = true;
                console.log("checked favorites: true");
                return;
            } 
      }
          console.log("finished for loop");
    },
    swipeRight(){
        return fetch(`${process.env.VUE_APP_REMOTE_API}/test/SwipeRight`, {
      method: 'POST',
      headers: {
          "Content-Type": "application/json",
          Authorization: 'Bearer ' + auth.getToken(),
      },
      credentials: 'same-origin',
      body: JSON.stringify(this.current)
  })
    },
    swipeLeft(){
          return fetch(`${process.env.VUE_APP_REMOTE_API}/test/SwipeLeft`, {
      method: 'POST',
      headers: {
          "Content-Type": "application/json",
          Authorization: 'Bearer ' + auth.getToken(),
      },
      credentials: 'same-origin',
      body: JSON.stringify(this.current)
  })
    },
    clearSwipes(){
        return fetch(`${process.env.VUE_APP_REMOTE_API}/test/ClearSwipes`, {
      method: 'DELETE',
      headers: {
          "Content-Type": "application/json",
          Authorization: 'Bearer ' + auth.getToken(),
      },
        credentials: 'same-origin',
        body: JSON.stringify(this.current)
    })
  },

},
  mounted() {
    this.populateRestaurants();
    this.clearSwipes();
  }
}
</script>

<style lang="scss" scoped>
.container {
  background: #eceff1;
  width: 90vh;
  height: 100vh;
}



.footer {
  width: 23vw;
  bottom: 0;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  padding-bottom: 30px;
  justify-content: space-around;
  align-items: center;
}

.btn {
  position: relative;
  width: 50px;
  height: 50px;
  padding: .2rem;
  border-radius: 2%;
  background-color: white;
  box-shadow: 0 6px 6px -3px rgba(0,0,0,0.02), 0 10px 14px 1px rgba(0,0,0,0.02), 0 4px 18px 3px rgba(0,0,0,0.02);
  cursor: pointer;
  transition: all .3s ease;
  user-select: none;
  -webkit-tap-highlight-color:transparent;
  &:active {
    transform: translateY(4px);
  }
  i {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    &::before {
      content: '';
    }
  }
  &--like {
    color: green;
  }
  &--decline {
    color: red;
  }
}

.flex {
  display: flex;
  &--center {
    align-items: center;
    justify-content: center;
  }
}

.fixed {
  position: fixed;
  &--center {
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
  }
}
.rounded-borders {
  border-radius: 12px;
}
.card {
  width: 80vw;
  max-width: 400px;
  height: 60vh;
  color: white;
  img {
    object-fit: cover;
    display: block;
    width: 100%;
    height: 100%;
  }
  &--one {
    box-shadow: 0 1px 3px rgba(0,0,0,.2), 0 1px 1px rgba(0,0,0,.14), 0 2px 1px -1px rgba(0,0,0,.12);
  }
  &--two {
    transform: translate(-50%, -48%);
    box-shadow: 0 6px 6px -3px rgba(0,0,0,.2), 0 10px 14px 1px rgba(0,0,0,.14), 0 4px 18px 3px rgba(0,0,0,.12);
  }
  &--three {
    background: rgba(black, .8);
    transform: translate(-50%, -47%);
    box-shadow: 0 10px 13px -6px rgba(0,0,0,.2), 0 20px 31px 3px rgba(0,0,0,.14), 0 8px 38px 7px rgba(0,0,0,.12);
  }
  .text {
    position: absolute;
    text-align: left;
    bottom: 0;
    width: 100%;
    background:black;
    background:rgba(0,0,0,0.5);
    border-bottom-right-radius: 12px;
    border-bottom-left-radius: 12px;
    padding-left: 10px;

    span {
      color: rgb(0, 209, 0);
      float: right;
      font-weight: normal;
      margin-right: 5px;
      padding-right: 1px;
      font-size: 20px;
      font-weight: 700;
    }

    i {
      
      float: left;
      color: yellow;
      font-size: 20px;
      cursor: pointer;
    }
    

  }
}

.material-icons{
cursor: pointer;
}

.transition {
  animation: appear 200ms ease-in;
}

@keyframes appear {
  from {
    transform: translate(-48%, -48%);
  }
  to {
    transform: translate(-50%, -50%);
  }
}
</style>
