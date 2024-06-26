<script setup lang="ts">
import { CalculationResponse } from "../types";

defineProps<{
  response: CalculationResponse;
}>();

const formatCurrency = (value: number) => `$${value.toLocaleString('en-US', { minimumFractionDigits: 2 })}`;
</script>

<template>
    <h2>Calculation</h2>
    <table class="calculation-result">
        <tbody>
            <tr>
                <th>Basic Fee</th>
                <td>{{ formatCurrency(response.basicFee) }}</td>
            </tr>
            <tr>
                <th>Special Fee</th>
                <td>{{ formatCurrency(response.specialFee) }}</td>
            </tr>
            <tr>
                <th>Association Fee</th>
                <td>{{ formatCurrency(response.associationFee) }}</td>
            </tr>
            <tr>
                <th>Storage Fee</th>
                <td>{{ formatCurrency(response.storageFee) }}</td>
            </tr>
            <tr class="total">
                <th>Total</th>
                <td>{{ formatCurrency(response.total) }}</td>
            </tr>
        </tbody>
    </table>
</template>

<style>
h2 {
    background-color: #aaa;
    font-weight: 200;
    margin: 0;
    padding: 10px 0;
    text-align: center;
}

table.calculation-result {
    border-collapse: collapse;
    border: none;
    width: 100%;
}

table.calculation-result th, table.calculation-result td {
    border-bottom: solid 1px #aaa;
    padding: 10px 15px;
}

table.calculation-result th {
    text-align: left;
}

table.calculation-result td {
    text-align: right;
}

table.calculation-result .total {
    font-weight: bold;
}
</style>
