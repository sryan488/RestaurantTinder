<template>
    <div>
        <p></p>
        <div class="row">
            <div class="col-sm-0 col-lg-4"></div>
          <div class="card border-primary mb-3 text-center col-sm-12 col-lg-4" style="max-width: 30rem;">
              <div class="card-header"><h1><i class="fas fa-cogs" style="color:#E95420"></i>  Preferences </h1></div>
        <form id="prefForm" v-on:submit.prevent="submitPreferences" >
            <div>
                <p></p>
                    <label for=searchText><legend> What kind of food do you want?</legend></label>
                    <input type="text" name="searchText" v-model="form.searchText" placeholder="e.g. Italian, Pizza" class="form-control form-control-lg">
                        <div class="form-group">
                        <label class="col-form-label col-form-label-lg" for="inputLarge"><legend> Location </legend></label>
                        <input class="form-control form-control-lg" type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH" id="inputLarge">
                        </div>
                    <legend>Distance </legend>
                  <div class="form-group">
                    <select class="custom-select" v-model="form.searchRadius">
                    <option selected="">Distance</option>
                    <option value="5" name="searchRadius">5 mi</option>
                    <option value="10" name="searchRadius">10 mi</option>
                    <option value="15" name="searchRadius">15 mi</option>
                    <option value="20" name="searchRadius">20 mi</option>
                    <option value="25" name="searchRadius">25 mi</option>
                    </select>
                </div>
                                 <legend>Max Price </legend>
                <div class="form-group">
                    <div class="btn-group btn-group-toggle btn-block" >
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 1 }">
                        <input type="radio" name="options" id="option1" autocomplete="off" value="1" v-model="form.maxPriceRange"  >
                        <div class="fa-spin-hover"><i class="fas fa-dollar-sign"></i></div> </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 2 }">
                        <input type="radio" name="options" id="option2" autocomplete="off" value="2" v-model="form.maxPriceRange" >
                     <div class="fa-spin-hover"><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i></div> </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 3 }">
                        <input type="radio" name="options" id="option3" autocomplete="off" value="3" v-model="form.maxPriceRange" >
                     <div class="fa-spin-hover"><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i></div> </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 4 }">
                        <input type="radio" name="options" id="option4" autocomplete="off" value="4" v-model="form.maxPriceRange"  >
                     <div class="fa-spin-hover"><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i><i class="fas fa-dollar-sign"></i></div> </label>
                    </div>
                </div>
                    <!-- <p> Chosen price range: {{form.maxPriceRange}} </P> -->
                <p>
                <button type="submit" class="btn btn-primary btn-lg btn-block ">Submit <i class="far fa-arrow-alt-circle-right"></i></button>
                </p>
            </div>
        </form>

          </div> 
            </div>
                    <div class="row">
            <div class="col-sm-0 col-lg-4">col-4</div>

<div class="card border-primary mb-3 text-center col-sm-12 col-lg-4" style="max-width: 30rem;">
    <favorites></favorites>
    <p></p>
</div>

</div>
 </div>
  
</template>

<script>
import auth from '../auth';
import favorites from "@/views/Favorites";

// import blacklist from "@/views/Blacklist";

export default {
  name: 'preferenceForm',
  components: {
      favorites,
    //   blacklist
  },
  data() {
      return {
            preference: {},
            form: {
                searchText: "",
                maxPriceRange: 0,
                location: "",
                searchRadius: 0
            }
      }
  },
  methods: {
      submitPreferences(){
        return fetch(`${process.env.VUE_APP_REMOTE_API}/test`, {
            method: 'PUT',
            headers: {
                "Content-Type": "application/json",
                Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            body: JSON.stringify(this.form)
        })
        .then((response) => {
            if (response.ok) {
                this.$router.push('/results');
                this.clearSwipes();
            }})
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
      }
  },
    created() {
    // load the preferences
    fetch(`${process.env.VUE_APP_REMOTE_API}/test`, {
            headers: {
            "Content-Type": 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            })
      .then((response) => {
        return response.json();
            })
            .then((preference) => {
                this.preference = preference;
                this.form.searchText = preference.searchText;
                this.form.maxPriceRange = preference.maxPriceRange;
                this.form.location = preference.location;
                this.form.searchRadius = preference.searchRadius;
                })
                .catch((err) => console.error(err));
  }
}
</script>

<style scoped>

</style>