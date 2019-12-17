<template>
    <div>
        <p></p>
        <div class="row">
            <div class="col-4">col-4</div>
          <div class="card border-primary mb-3 text-center col-4" style="max-width: 30rem;">
              <div class="card-header">Your Preferences <i class="fas fa-key"></i></div>
        <h1> LAST PREFERENCES </h1>
        <p>JSON: {{preference}}</p>

        <!-- <div v-for="preference in preferences" v-bind:key="preference.userID"> -->
            <div>
            <p>
                Preferences: {{preference.searchText}}
            </p>
            <p>
                Location: {{preference.location}}
            </p>
            <p>
                Price Range: {{preference.maxPriceRange}}
            </p>

            </div>

        <form id="prefForm" v-on:submit.prevent="submitPreferences" >
            <div>
                <h2> searchText </h2>
                    <label for=searchText>What kind of food do you want?</label>
                        <input type="text" name="searchText" v-model="form.searchText" placeholder="e.g. Italian, Pizza" class="form-control form-control-lg">
                        <p> Search Text: {{form.searchText}} </P>
                

                 <legend>Price Range </legend>
                <div class="form-group">
                    <div class="custom-control custom-radio">
                    <input type="radio" id="customRadio1" name="maxPriceRange" value="1" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 1" class="custom-control-input">
                    <label class="custom-control-label" for="customRadio1"> $ </label>
                    </div>
                    <div class="custom-control custom-radio">
                    <input type="radio" id="customRadio2" name="maxPriceRange" value="2" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 2" class="custom-control-input">
                    <label class="custom-control-label" for="customRadio2"> $$ </label>
                    </div>
                    <div class="custom-control custom-radio">
                    <input type="radio" id="customRadio3" name="maxPriceRange" value="3" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 3" class="custom-control-input">
                    <label class="custom-control-label" for="customRadio3"> $$$ </label>
                    </div>
                        <div class="custom-control custom-radio">
                    <input type="radio" id="customRadio4" name="maxPriceRange" value="4" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 4" class="custom-control-input">
                    <label class="custom-control-label" for="customRadio4"> $$$$ </label>
                    </div>
                    Chosen price range: {{form.maxPriceRange}}
                </div>
  <!--                  <label for=$>$</label>
                        <input type="radio" name="maxPriceRange" value="1" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 1">
                    <label for=$$>$$</label>
                        <input type="radio" name="maxPriceRange" value="2" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 2">
                    <label for=$$$>$$$</label>
                        <input type="radio" name="maxPriceRange" value="3" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 3">
                    <label for=$$$$>$$$$</label>
                        <input type="radio" name="maxPriceRange" value="4" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 4">
                        <p> Chosen price range: {{form.maxPriceRange}} </P>
-->
                <h2> Location </h2>
                   <!-- <label for=location>Location: </label>
                        <input type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH">
                    -->
                        <div class="form-group">
                        <label class="col-form-label col-form-label-lg" for="inputLarge">Location</label>
                        <input class="form-control form-control-lg" type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH" id="inputLarge">
                        </div>
                        <p> Chosen location: {{form.location}} </P>
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

                  <div class="form-group">
                    <select class="custom-select">
                    <option selected="">Distance</option>
                    <option value="5" name="searchRadius">5 mi</option>
                    <option value="10" name="searchRadius">10 mi</option>
                    <option value="15" name="searchRadius">15 mi</option>
                    <option value="20" name="searchRadius">20 mi</option>
                    <option value="25" name="searchRadius">25 mi</option>
                    </select>
                </div>
                <p>
                <button type="submit" class="btn btn-primary btn-lg btn-block">submit</button>
                </p>
            </div>
        </form>
          </div> </div>


 </div>
    </div>
  
</template>

<script>
import auth from '../auth';
export default {
  name: 'preferenceForm',
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