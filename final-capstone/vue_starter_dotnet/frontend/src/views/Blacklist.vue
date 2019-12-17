<template>
    <div>
        <h1>BLACKLIST</h1>
        <div v-for="restaurant in blacklist" v-bind:key="restaurant">

        </div>
    </div>
</template>

<script>
export default {
    name: 'blacklist.vue',
    data() {
        return {
            blacklist: []
        }
    },
    created() {
        //load the blacklist
        fetch(`https://localhost:44392/api/test/GetBlacklist`, {
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
                    .then((blacklist) => {
                        this.blacklist = blacklist;
                        })
                        .catch((err) => console.error(err));
    }
}
</script>

<style scoped>

</style>