<script setup lang="ts">
import { ref, watchEffect } from "vue";
import { VehicleType, CalculationResponse } from "../types";
import BidCalculatorResult from "./BidCalculatorResult.vue";

const response = ref<CalculationResponse | null>(null);
const basePrice = ref<number | null>(null);
const vehicleType = ref(VehicleType.Common);

watchEffect(async (onCancel) => {
    if (basePrice.value > 0) {
        try {
            const controller = new AbortController();
            onCancel(() => controller.abort());

            response.value = await (
                await fetch("/api/calculate", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        basePrice: basePrice.value,
                        vehicleType: vehicleType.value,
                    }),
                    signal: controller.signal,
                })
            ).json();
        } catch {
            response.value = null;
        }
    } else {
        response.value = null;
    }
});
</script>

<template>
    <form class="calulation-form">
        <fieldset>
            <label>
                Vehicle Type:
                <select v-model="vehicleType">
                    <option v-for="[value, key] in Object.entries(VehicleType).filter(([_, k]) =>
                        Number.isInteger(k)
                    )" :key="key" :value="key">
                        {{ value }}
                    </option>
                </select>
            </label>
        </fieldset>
        <fieldset>
            <label>Base Price: <input type="number" v-model="basePrice" min="0" /></label>
        </fieldset>
    </form>
    <BidCalculatorResult v-if="response !== null" :response="response" />
</template>

<style>
.calulation-form fieldset {
    border: none;
    padding: 10px 15px;
}

.calulation-form label {
    font-weight: bold;
    min-width: 200px;
}

.calulation-form input, .calulation-form select {
    border: solid 1px #aaa;
    border-radius: 4px;
    padding: 4px;
}
</style>
