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
                City: {{preference.city}}
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
                    <label for=city>City: </label>
                        <input type="text" name="city" v-model="form.city">
                        <p> Chosen location: {{form.city}} </P>
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
export default {
  name: 'preferencesForm',
  data() {
      return {
            userID: 2,
            preference: {},
            form: {
                categories: [],
                priceRange: 0,
                city: "",
                searchRadius: 0
            }
      }
  },
  methods: {
      submitPreferences(){
        // return fetch(`https://jsonplaceholder.typicode.com/users/`, this.form)
        return fetch(`https://localhost:44392/api/test/${this.userID}`, {
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
          });
      }
  },
    created() {
    // load the preferences
    fetch(`https://localhost:44392/api/test/${this.userID}`, {
            headers: {
            Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            })
      .then((response) => {
        return response.json();
            })
            .then((preference) => {
                this.preference = preference;
                })
                .catch((err) => console.error(err));
  }
}
</script>

<style scoped>

</style>