<template>
    <div>
    <h1> FILL OUT THIS FORM </h1>
        <form v-on:submit.prevent="submitPreferences">
            <div>
                <h2> Cuisine </h2>
                    <label for=italian>Italian </label>
                        <input type="checkbox" v-model="form.cuisine">
                    <label for=cuisine>Chinese </label>
                        <input type="checkbox" v-model="form.cuisine">
                    <label for=cuisine>Mexican </label>
                        <input type="checkbox" v-model="form.cuisine">
                    <label for=cuisine>American </label>
                        <input type="checkbox" v-model="form.cuisine">
                <h2> Price Range </h2>
                    <label for=$>$ </label>
                        <input type="checkbox" v-model="form.priceRange">
                    <label for=$$>$$ </label>
                        <input type="checkbox" v-model="form.priceRange">
                    <label for=$$$>$$$ </label>
                        <input type="checkbox" v-model="form.priceRange">
                    <label for=$$$$>$$$$ </label>
                        <input type="checkbox" v-model="form.priceRange">
                <h2> Location </h2>
                    <label for=city>City: </label>
                        <input type="text" v-model="form.city">
                <h2> Distance 
                    <select v-model="form.city">
                        <option value="5" >5 mi</option>
                        <option value="10">10 mi</option>
                        <option value="25">25 mi</option>
                        <option value="50">50 mi</option>
                        <option value="100">100 mi</option>
                    </select>
                </h2>
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
  }
}
</script>

<style scoped>

</style>