<template>
    <div>
    <h1> FILL OUT THIS FORM </h1>
        <form v-on:submit.prevent="submitPreferences">
            <div>
                <h2> Cuisine </h2>
                <label for=italian>Italian </label>
                <input type="checkbox" >
                <label for=cuisine>Chinese </label>
                <input type="checkbox" >
                <label for=cuisine>Mexican </label>
                <input type="checkbox" >
                <label for=cuisine>American </label>
                <input type="checkbox" >
                <h2> Price Range </h2>
                <label for=$>$ </label>
                <input type="checkbox" >
                <label for=$$>$$ </label>
                <input type="checkbox" >
                <label for=$$$>$$$ </label>
                <input type="checkbox" >
                <label for=$$$$>$$$$ </label>
                <input type="checkbox" >
                <h2> Location </h2>
                <label for=city>City: </label>
                <input type="text" >
                <h2> Distance 
                    <select>
                        <option value="5 mi">5 mi</option>
                        <option value="10 mi">10 mi</option>
                        <option value="25 mi">25 mi</option>
                        <option value="50 mi">50 mi</option>
                        <option value="100 mi">100 mi</option>
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
          cuisine: [],
          priceRange: [],
          city: "",
          searchRadius: 0
      }
  }
}
</script>

<style scoped>

</style>