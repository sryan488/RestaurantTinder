<template>
    <div>
        <h1>FAVORITES</h1>
        <ul v-for="restaurant in favoritesList" v-bind:key="restaurant" class="list-group">
            <li class="list-group-item" >{{restaurant.name}}</li>
        </ul>
    </div>
</template>

<script>
import auth from '../auth';
export default {
    name: 'favorites.vue',
    data() {
        return {
            favoritesList: []
        }
    },
    created() {
        //load the blacklist
        fetch(`https://localhost:44392/api/test/GetFavorites`, {
            headers: {
            "Content-Type": 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
            },
            credentials: 'same-origin',
            })
            .then((response) => {
                if (response.ok) {
                    return response.json();
                }
                else if (!response.ok) {
                    this.$router.push('/preferenceForm')
                }})
                    .then((favoritesList) => {
                        this.favoritesList = favoritesList;
                        })
                        .catch((err) => console.error(err));
    }

}
</script>

<style scoped>

</style>