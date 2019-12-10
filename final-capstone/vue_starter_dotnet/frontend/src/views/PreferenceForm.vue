<template>
    <div>
    <h1> FILL OUT THIS FORM </h1>
        <form id="prefForm" v-on:submit.prevent="submitPreferences" method="post">
            <div>
                <h2> Cuisine </h2>
                    <label for=italian>Italian </label>
                        <input type="checkbox" name="cuisine" value="Italian" v-model="form.cuisine">
                    <label for=cuisine>Chinese </label>
                        <input type="checkbox" name="cuisine" value="Chinese" v-model="form.cuisine">
                    <label for=cuisine>Mexican </label>
                        <input type="checkbox" name="cuisine" value="Mexican" v-model="form.cuisine">
                    <label for=cuisine>American </label>
                        <input type="checkbox" name="cuisine" value="American" v-model="form.cuisine">
                        <p> Chosen cuisine: {{form.cuisine}} </P>
                <h2> Price Range </h2>
                    <label for=$>$ </label>
                        <input type="checkbox" name="priceRange" value="1" v-model="form.priceRange">
                    <label for=$$>$$ </label>
                        <input type="checkbox" name="priceRange" value="2" v-model="form.priceRange">
                    <label for=$$$>$$$ </label>
                        <input type="checkbox" name="priceRange" value="3" v-model="form.priceRange">
                    <label for=$$$$>$$$$ </label>
                        <input type="checkbox" name="priceRange" value="4" v-model="form.priceRange">
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
          form: {
          cuisine: [],
          priceRange: [],
          city: "",
          searchRadius: 0
          }
      }
  },
  methods: {
      submitPreferences(form){
        return fetch(`https://jsonplaceholder.typicode.com/users/`, JSON.stringify(form))
        .then((response) => {
        return response.json();
          });

      }
  }
}
  

</script>

<style scoped>

</style>