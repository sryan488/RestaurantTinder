<template>
    <div>
        <p></p>
        <div class="row">
            <div class="col-sm-0 col-lg-4">col-4</div>
          <div class="card border-primary mb-3 text-center col-sm-12 col-lg-4" style="max-width: 30rem;">
              <div class="card-header"><h1><i class="fas fa-check"></i>  Preferences </h1></div>

<!-- vvv We used these to check the info from the form object coming in from the API vvv -->
        <!-- <h1> LAST PREFERENCES </h1>
        <p>JSON: {{preference}}</p> -->
        <!-- <div v-for="preference in preferences" v-bind:key="preference.userID"> -->
            <!-- <div>
            <p>
                Preferences: {{preference.searchText}}
            </p>
            <p>
                Location: {{preference.location}}
            </p>
            <p>
                Price Range: {{preference.maxPriceRange}}
            </p>
            </div> -->

        <form id="prefForm" v-on:submit.prevent="submitPreferences" >
            <div>
                <p></p>
                    <label for=searchText><legend> What kind of food do you want?</legend></label>
                    <input type="text" name="searchText" v-model="form.searchText" placeholder="e.g. Italian, Pizza" class="form-control form-control-lg">
<!-- vvv We used this binding to check that we were accurately bound to the form object's properties vvv -->
                        <!-- <p> Search Text: {{form.searchText}} </P> -->
                
<!-- vvv We used this binding to check that we were accurately bound to the form object's properties vvv -->
                    <!-- Chosen price range: {{form.maxPriceRange}} </div> -->
  <!--                  <label for=$>$</label>
                        <input type="radio" name="maxPriceRange" value="1" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 1">
                    <label for=$$>$$</label>
                        <input type="radio" name="maxPriceRange" value="2" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 2">
                    <label for=$$$>$$$</label>
                        <input type="radio" name="maxPriceRange" value="3" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 3">
                    <label for=$$$$>$$$$</label>
                        <input type="radio" name="maxPriceRange" value="4" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 4">
-->
                   <!-- <label for=location>Location: </label>
                        <input type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH">
                    -->
                        <div class="form-group">
                        <label class="col-form-label col-form-label-lg" for="inputLarge"><legend> Location </legend></label>
                        <input class="form-control form-control-lg" type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH" id="inputLarge">
                        </div>
<!-- vvv We used this binding to check that we were accurately bound to the form object's properties vvv -->
                        <!-- <p> Chosen location: {{form.location}} </P> -->
 <!--               <h2> Distance 
                    <select v-model="form.searchRadius">
                        <option value="5"  name="searchRadius" >5 mi</option>
                        <option value="10" name="searchRadius">10 mi</option>
                        <option value="15" name="searchRadius">15 mi</option>
                        <option value="20" name="searchRadius">20 mi</option>
                        <option value="25" name="searchRadius">25 mi</option>
                    </select>
                        <p>Chosen distance: {{form.searchRadius}}</P>
                </h2> -->
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
                        $ </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 2 }">
                        <input type="radio" name="options" id="option2" autocomplete="off" value="2" v-model="form.maxPriceRange" >
                     $$ </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 3 }">
                        <input type="radio" name="options" id="option3" autocomplete="off" value="3" v-model="form.maxPriceRange" >
                     $$$ </label>
                        <label class="btn btn-primary" :class="{ 'active': form.maxPriceRange == 4 }">
                        <input type="radio" name="options" id="option4" autocomplete="off" value="4" v-model="form.maxPriceRange"  >
                     $$$$ </label>
                    </div>
                </div>
                    <!-- <p> Chosen price range: {{form.maxPriceRange}} </P> -->
                <p>
                <button type="submit" class="btn btn-primary btn-lg btn-block">submit</button>
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
import favorites from "@/views/Favorites"
import blacklist from "@/views/Blacklist";

export default {
  name: 'preferenceForm',
  components: {
      favorites,
      blacklist
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
        return fetch(`https://localhost:44392/api/test`, {
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
                this.$router.push('/results')
            }})
      }
  },
    created() {
    // load the preferences
    fetch(`https://localhost:44392/api/test`, {
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