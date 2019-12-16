<template>
    <div>
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
    <h1> FILL OUT THIS FORM </h1>
        <form id="prefForm" v-on:submit.prevent="submitPreferences" >
            <div>
                <h2> searchText </h2>
                    <label for=searchText>What kind of food do you want?</label>
                        <input type="text" name="searchText" v-model="form.searchText" placeholder="e.g. Italian, Pizza">
                        <p> Search Text: {{form.searchText}} </P>
                <h2> Price Range </h2>
                    <label for=$>$</label>
                        <input type="radio" name="maxPriceRange" value="1" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 1">
                    <label for=$$>$$</label>
                        <input type="radio" name="maxPriceRange" value="2" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 2">
                    <label for=$$$>$$$</label>
                        <input type="radio" name="maxPriceRange" value="3" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 3">
                    <label for=$$$$>$$$$</label>
                        <input type="radio" name="maxPriceRange" value="4" v-model="form.maxPriceRange" :checked="form.maxPriceRange == 4">
                        <p> Chosen price range: {{form.maxPriceRange}} </P>

                <h2> Location </h2>
                    <label for=location>Location: </label>
                        <input type="text" name="location" v-model="form.location" placeholder="e.g. Cleveland, OH">
                        <p> Chosen location: {{form.location}} </P>
                <h2> Distance 
                    <select v-model="form.searchRadius">
                        <option value="5"  name="searchRadius" >5 mi</option>
                        <option value="10" name="searchRadius">10 mi</option>
                        <option value="15" name="searchRadius">15 mi</option>
                        <option value="20" name="searchRadius">20 mi</option>
                        <option value="25" name="searchRadius">25 mi</option>
                    </select>
                        <p>Chosen distance: {{form.searchRadius}}</P>
                </h2>
                <button type="submit"> submit </button>
            </div>
        </form>
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
                this.form.searchText = "";
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