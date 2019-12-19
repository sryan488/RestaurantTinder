<template> 
<div>
    <h1>LIKES</h1>
    <ul v-for="restaurants in rightSwipes" v-bind:key="restaurants" class="list-group">
        <li class="list-group-item">{{restaurants.name}}</li>
    </ul>
    <h1>DISLIKES</h1>
    <ul v-for="restaurants in leftSwipes" v-bind:key="restaurants" class="list-group">
        <li class="list-group-item">{{restaurants.name}}</li>
    </ul>

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