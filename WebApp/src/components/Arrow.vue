<template>
    <div>
        <input type="button" value="Solve!" @click="solve()"/>
    </div>
</template>
        <!-- <img src="@/assets/Arrow.svg" /> -->

<script>
export default {
    methods:{
        solve(){
            this.$store.dispatch('solve');
        }
    }
}
</script>


<style scoped>
div{
    height:452px;
    width:200px;
    float:left;
}
</style>
