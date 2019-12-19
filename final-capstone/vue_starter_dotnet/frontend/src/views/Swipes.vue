<template> 
<div>
<div class="row">
<div class="col-sm-0 col-lg-4">col-4</div>

<div class="card border-primary mb-3 text-center col-sm-12 col-lg-4" style="max-width: 30rem;">
    <h1>LIKES</h1>
    <ul v-for="restaurants in swipes" v-bind:key="restaurants" class="list-group">
        <li v-if="restaurants.liked === true" class="list-group-item">{{restaurants.name}}</li>
    </ul>
    <h1>DISLIKES</h1>
    <ul v-for="restaurants in swipes" v-bind:key="restaurants" class="list-group">
        <li v-if="restaurants.liked === false" class="list-group-item">{{restaurants.name}}</li>
    </ul>
</div>

<div class="col-sm-0 col-lg-4">col-4</div>
</div>
</div>
</template>

<script>
import auth from '../auth';
export default {
name: 'swipes.vue',
    data() {
        return {
            swipes: [],
            rightSwipes: [],
            leftSwipes: []
        }
    },
    computed: {

    },
    methods: {
        populateSwipes(){
            fetch(`https://localhost:44392/api/test/GetSwipes`, {
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
                    .then((swipes) => {
                        this.swipes = swipes;
                        this.populateLeftAndRight();

                        })
                            .catch((err) => console.error(err));
    },
    populateLeftAndRight(){
        let rightIndex = 0;
        let leftIndex = 0;
        for(let i = 0; i < this.swipes.length; i++){
            if (this.swipes[i].liked == true){
                this.rightSwipes[rightIndex] = this.swipes[i];
                rightIndex++;
            }
            if (this.swipes[i].liked == false){
                this.leftSwipes[leftIndex] = this.swipes[i];
                leftIndex++;
            }
        }
    }
    },
    created(){
        this.populateSwipes();
    }
}
</script>

<style scoped>

</style>