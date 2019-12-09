<template>
    <div>
    <h1> FILL OUT THIS FORM </h1>
        <form v-on:submit.prevent="submitPreferences">
            <div>
                <label for=cuisine>Name:</label><input id="cuisine" type="text" v-model="preferencesForm.cuisine" />
            </div>
            <div>
                <label for=price>Name:</label><input id="price" type="number" v-model="preferencesForm.price" />
            </div>
            <div>
                <label for=location>Name:</label><input id="location" type="text" v-model="preferencesForm.location" />
            </div>
            <div>
                <label for=distance>Name:</label><input id="distance" type="number" v-model="preferencesForm.distance" />
            </div>

        </form>
    </div>
</template>

<script>
export default {
  name: 'preferencesForm',
  data() {
      return {
          cuisine: "",
          price: 0,
          location: "",
          distance: 0
      }
  }
}
</script>

<style scoped>

</style>