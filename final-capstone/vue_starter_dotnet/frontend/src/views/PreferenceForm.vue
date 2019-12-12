<template>
    <div>
        <h1> LAST PREFERENCES </h1>
        <p>JSON: {{preference}}</p>

        <!-- <div v-for="preference in preferences" v-bind:key="preference.userID"> -->
            <div>
            <p>
                Preferences: {{preference.categories}}
            </p>
            <p>
                Location: {{preference.location}}
            </p>
            <p>
                Price Range: {{preference.priceRange}}
            </p>

            </div>
    <h1> FILL OUT THIS FORM </h1>
        <form id="prefForm" v-on:submit.prevent="submitPreferences" >
            <div>
                <h2> categories </h2>
                    <label for=italian>Italian </label>
                        <input type="checkbox" name="categories" value="Italian" v-model="form.categories" :checked="form.categories.includes('Italian')">
                    <label for=categories>Chinese </label>
                        <input type="checkbox" name="categories" value="Chinese" v-model="form.categories" :checked="form.categories.includes('Chinese')">
                    <label for=categories>Mexican </label>
                        <input type="checkbox" name="categories" value="Mexican" v-model="form.categories" :checked="form.categories.includes('Mexican')">
                    <label for=categories>American </label>
                        <input type="checkbox" name="categories" value="American" v-model="form.categories" :checked="form.categories.includes('American')">
                        <p> Chosen categories: {{form.categories}} </P>
                <h2> Price Range </h2>
                    <label for=$>$ </label>
                        <input type="radio" name="priceRange" value="1" v-model="form.priceRange" :checked="form.priceRange == 1">
                    <label for=$$>$$ </label>
                        <input type="radio" name="priceRange" value="2" v-model="form.priceRange" :checked="form.priceRange == 2">
                    <label for=$$$>$$$ </label>
                        <input type="radio" name="priceRange" value="3" v-model="form.priceRange" :checked="form.priceRange == 3">
                    <label for=$$$$>$$$$ </label>
                        <input type="radio" name="priceRange" value="4" v-model="form.priceRange" :checked="form.priceRange == 4">
                        <p> Chosen price range: {{form.priceRange}} </P>

                <h2> Location </h2>
                    <label for=location>Location: </label>
                        <input type="text" name="location" v-model="form.location">
                        <p> Chosen location: {{form.location}} </P>
                <h2> Distance 
                    <select v-model="form.searchRadius">
                        <option value="5" name="searchRadius" >5 mi</option>
                        <option value="10" name="searchRadius">10 mi</option>
                        <option value="25" name="searchRadius">25 mi</option>
                        <option value="50" name="searchRadius">50 mi</option>
                        <option value="100" name="searchRadius">100 mi</option>
                    </select>
                        <p> Chosen distance: {{form.searchRadius}}</P>
                </h2>
                <button type="submit"> submit </button>
            </div>
        </form>
    </div>
</template>

<script>
import auth from '../auth';
export default {
  name: 'preferencesForm',
  data() {
      return {
            preference: {},
            form: {
                categories: [],
                priceRange: 0,
                location: "",
                searchRadius: 0
            }
      }
  },
  methods: {
      submitPreferences(){
        // return fetch(`https://jsonplaceholder.typicode.com/users/`, this.form)
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
        return response.json();
          })
            .then(this.$router.push('/results'));

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
                this.form.categories = preference.categories;
                this.form.priceRange = preference.priceRange;
                this.form.location = preference.location;
                this.form.searchRadius = preference.searchRadius;
                })
                .catch((err) => console.error(err));
  }
}
</script>

<style scoped>

</style>