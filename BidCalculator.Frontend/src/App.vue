<script setup lang="ts">
import BidCalculator from './components/BidCalculator.vue'
</script>

<template>
    <div class="wrapper">
        <h1>Bid Calculator</h1>
        <BidCalculator />
    </div>
</template>

<style>
* {
    font-family: 'Montserrat', 'Helvetica', 'Arial', sans-serif;
}

body {
    background-color: #eee;
}

.wrapper {
    background-color: white;
    border-radius: 20px;
    border: solid 1px #aaa;
    box-shadow: rgba(0,0,0,0.3) 0px 0px 20px;
    margin: 50px auto;
    min-width: 500px;
    overflow: hidden;
    width: 25vw;
}

h1 {
    background-color: #222;
    border-bottom: solid 1px #aaa;
    color: white;
    font-weight: 200;
    margin: 0;
    padding: 15px 0;
    text-align: center;
}
</style>
